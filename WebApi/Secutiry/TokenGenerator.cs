using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using ItecDashManager.Domain.Constants;
using ItecDashManager.Domain.Exceptions;

namespace ApiBase.Security
{
    public static class TokenGenerator
    {
        private static string TokenKey = Environment.GetEnvironmentVariable("TOKEN_KEY");

        public static string BuildToken(object properties, string[] niveisAcesso = null)
        {
            var claims = new List<Claim>();

            //if (properties != null)
            //{
            //    foreach (var property in properties.GetType().GetProperties())
            //    {
            //        var value = property.GetValue(properties, null);
            //        claims.Add(new Claim(property.Name, Newtonsoft.Json.JsonConvert.SerializeObject(value, new Newtonsoft.Json.JsonSerializerSettings()
            //        {
            //            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            //            ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore,
            //        })));
            //    }
            //}

            //aqui está criando o token apenas com tipos de dados não complexos. Caso seja necessário, ajustar rotina acima para que dependendo do tipo, serialize ou não. String ou array de int não devem ser serializados, porém caso seja um objeto, aí pode
            if (properties != null)
            {
                foreach (var property in properties.GetType().GetProperties())
                {
                    var value = property.GetValue(properties, null);

                    if (value != null)
                        claims.Add(new Claim(property.Name, value.ToString()));
                }
            }

            if (niveisAcesso != null)
            {
                foreach (var nivelAcesso in niveisAcesso)
                {
                    claims.Add(new Claim(ClaimTypes.Role, nivelAcesso));
                }
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(TokenKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                null,
                null,
                claims,
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        //public static string ReBuildToken(string token)
        //{
        //    var handler = new JwtSecurityTokenHandler();

        //    token = token.Replace("Bearer", "");
        //    token = token.Trim();

        //    var tokenAntigo = handler.ReadToken(token) as JwtSecurityToken;

        //    var id = tokenAntigo.Claims.First(claim => claim.Type == "id").Value;
        //    var accessLevel = tokenAntigo.Claims.First(claim => claim.Type == ClaimTypes.Role).Value;
        //    var email = tokenAntigo.Claims.First(claim => claim.Type == "email").Value;
        //    var name = tokenAntigo.Claims.First(claim => claim.Type == "name").Value;

        //    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(TokenKey));
        //    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        //    var claims = new[] {
        //        new Claim("id", Convert.ToString(id)),
        //        new Claim(ClaimTypes.Role, accessLevel),
        //        new Claim("email", email),
        //        new Claim("name", name),
        //    };

        //    var novoToken = new JwtSecurityToken(
        //        null,
        //        null,
        //        claims,
        //        signingCredentials: creds);

        //    return new JwtSecurityTokenHandler().WriteToken(novoToken);
        //}

        public static string GetUserEmail(this string token)
        {
            return token.GetValueByPropertyToString("user.email");
        }

        public static long GetUserBaseId(this string token)
        {
            return token.GetValueByPropertyToLong("user.id");
        }

        public static string GetValueByPropertyToString(this string token, string property)
        {
            return ExtractValueFromToken(token, property);
        }

        public static int GetValueByPropertyToInt(this string token, string property)
        {
            return Convert.ToInt32(ExtractValueFromToken(token, property));
        }

        public static long GetValueByPropertyToLong(this string token, string property)
        {
            return Convert.ToInt64(ExtractValueFromToken(token, property));
        }

        public static long[] GetValueByPropertyToLongArray(this string token, string property)
        {
            return JsonConvert.DeserializeObject<long[]>(ExtractValueFromToken(token, property));
        }

        public static bool GetValueByPropertyToBoolean(this string token, string property)
        {
            return Convert.ToBoolean(ExtractValueFromToken(token, property));
        }

        public static T[] GetValueByPropertyToArray<T>(this string token, string property)
        {
            var data = JsonConvert.DeserializeObject<T[]>(ExtractValueFromToken(token, property));
            return data;
        }

        public static List<T> GetValueByPropertyToList<T>(this string token, string property)
        {
            string value = token.GetValueByPropertyToString(property).Trim();

            if (value.StartsWith("[") && value.EndsWith("]"))
            {
                return value[1..^1].Split(",").Select(i =>
                {
                    if (typeof(T) == typeof(long))
                    {
                        return Convert.ToInt64(i);
                    }
                    else if (typeof(T) == typeof(int))
                    {
                        return Convert.ToInt32(i);
                    }
                    else if (typeof(T) == typeof(string))
                    {
                        if (i.StartsWith("\"") && i.EndsWith("\""))
                            return i[1..^1];

                        return i;
                    }
                    else
                    {
                        return Convert.ChangeType(i, typeof(T));
                    }
                }).Cast<T>().ToList();
            }
            else
            {
                throw new GlobalMessageExceptions(DefaultGlobalErrorsMessage.UNEXPECTED_ERROR);
            }
        }

        private static string ExtractValueFromToken(string token, string property)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwt = handler.ReadToken(token.Replace("Bearer", "").Trim()) as JwtSecurityToken;

            List<string> properties = property.Split(".").ToList();

            if (properties.Count() == 0)
            {
                throw new ArgumentNullException(nameof(property));
            }
            else
            {
                JwtPayload payload = jwt.Payload;

                foreach (string prop in properties)
                {
                    if (properties.IndexOf(prop) == properties.Count - 1)
                    {
                        var result = payload.GetValueOrDefault(prop);
                        if (result == null)
                            return "";

                        return payload.GetValueOrDefault(prop).ToString();
                    }
                    else
                        payload = JwtPayload.Deserialize(payload.GetValueOrDefault(prop)!.ToString());
                }

                throw new GlobalMessageExceptions(DefaultGlobalErrorsMessage.UNEXPECTED_ERROR);
            }
        }
    }
}
