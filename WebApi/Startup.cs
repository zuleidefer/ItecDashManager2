using ItecDashManager.Domain.Constants;
using ItecDashManager.WebApi.Mappings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DotNetEnv;
using ItecDashManager.Domain.Interfaces.ServiceInterfaces;
using ItecDashManager.Service.Services;
using ItecDashManager.Domain.Interfaces.RepositoryInterfaces;
using ItecDashManager.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using ItecDashManager.Data.Context;
namespace ItecDashManager.WebApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            Env.Load();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var tokenKey = Environment.GetEnvironmentVariable("TOKEN_KEY");

            if(string.IsNullOrEmpty(tokenKey))
            {
                throw new System.Exception("TOKEN_KEY não encontrado. Verifique se o .env está configurado corretamente");
            }

            var key = Encoding.UTF8.GetBytes(tokenKey);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = false,
                    };
                });

            services.AddAutoMapper(typeof(AutoMapperProfileDTOs), typeof(AutoMapperProfileViewModels));

          
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAngularDev",
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:4200") 
                               .AllowAnyHeader()
                               .AllowAnyMethod();
                    });
            });

            services.AddControllers()
                    .AddNewtonsoftJson();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddDbContext<DataContext>(options =>
                options.UseNpgsql(EnvironmentConstants.CONNECTION_STRING));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCors("AllowAngularDev"); 

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
