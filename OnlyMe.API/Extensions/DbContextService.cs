using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlyMe.DAL.Context;
using OnlyMe.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlyMe.API.Extensions
{
    public static class DbContextService
    {
        public static void ConfigureDbContext(this IServiceCollection services, IConfiguration Configuration)
        {
            var connectionString = Configuration.GetConnectionString("onlymecon");
            services.AddDbContext<OnlyMeDBContext>(options =>
             options.UseSqlServer(connectionString));

            services.AddIdentity<ApplicationUser, IdentityRole>(options => {
                options.SignIn.RequireConfirmedAccount = true;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 2;
                options.Password.RequiredUniqueChars = 0;
                options.User.RequireUniqueEmail = false;
            })
                .AddEntityFrameworkStores<OnlyMeDBContext>()
                 .AddDefaultTokenProviders();

            services.AddIdentityServer()
               .AddApiAuthorization<ApplicationUser, OnlyMeDBContext>();
        }
    }
}
