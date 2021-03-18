using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OnlyMe.API.Extensions;
using OnlyMe.API.MapperConfig;
using OnlyMe.DAL.Context;
using OnlyMe.Repository.Interfaces;
using OnlyMe.Repository.Repositories;

namespace OnlyMe.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        string coretest = "test";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // DB Register
            services.AddTransient<DbContext, OnlyMeDBContext>();

            services.ConfigureDbContext(Configuration);

            //add Configuatation mapping
            services.AutoMapperConfiguatation(typeof(Startup));

            //Repositories Configurations
            services.AddScoped(typeof(IRepository<,>), typeof(EfRepository<,>));

            // Service Configuration
            services.ConfigureDependencies();

            // Authentication Repository
            services.ConfigureApiAuth(Configuration);

            //cors
            services.AddCors(option =>
            {
                option.AddPolicy(coretest,
                    builder =>
                    {
                        builder.AllowAnyOrigin();
                        builder.AllowAnyMethod();
                        builder.AllowAnyHeader();
                    });
            });

            //Controllers
            services.AddControllers()
                .AddNewtonsoftJson(options =>
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseStaticFiles();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            // for Authentication and Authorizations
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseOpenApi();
            app.UseSwaggerUi3();

            //use core
            app.UseCors(coretest);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
