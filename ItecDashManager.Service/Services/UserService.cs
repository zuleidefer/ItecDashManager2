using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ItecDashManager.Domain.Constants;
using ItecDashManager.Domain.Entities.User;
using ItecDashManager.Domain.Interfaces.RepositoryInterfaces;
using ItecDashManager.Domain.Interfaces.ServiceInterfaces;
using Microsoft.IdentityModel.Tokens;

namespace ItecDashManager.Service.Services;

public class UserService : IUserService

{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task<User> AuthenticateAsync(string email, string password)
    {
        var user = await _userRepository.GetOneByEmailAsync(email);

        if (user == null)
            return null;


        if (user.Password != password)
            return null;

        return await Task.FromResult(user);
    }

    public object GetTokenData(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(EnvironmentConstants.TOKEN_KEY);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Email, user.Email)
            }),
            Expires = DateTime.UtcNow.AddHours(2),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}


