using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlyMe.API.Extensions
{
    public static class ApiAuthService
    {
        public static void ConfigureApiAuth(this IServiceCollection services, IConfiguration Configuration)
        {
            string key = Configuration.GetSection("JwtConfig").GetSection("secret").Value; //this should be same which is used while creating token     
            var issuer = "http://localhost:9222";  //this should be same which is used while creating token 
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = issuer,
                    ValidAudience = issuer,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
                };
                options.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = context =>
                    {
                        if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                        {
                            context.Response.Headers.Add("Token-Expired", "true");
                        }
                        return Task.CompletedTask;
                    }
                };
            });
            //services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<NasigFactoryDBContext>();

        }
    }
}
