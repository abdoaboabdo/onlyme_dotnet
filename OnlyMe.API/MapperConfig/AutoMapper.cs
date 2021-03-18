using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using OnlyMe.API.MapperConfig.MapperProfile;
using OnlyMe.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlyMe.API.MapperConfig
{
    public static class AutoMapper
    {
        public static void AutoMapperConfiguatation(this IServiceCollection services, Type type)
        {
            services.AddAutoMapper(type);
            var mapping = new MapperConfiguration(mc =>
            {
                //LookUps
                mc.AddProfile(new CategoryProfile());
                mc.AddProfile(new VarietyProfile());
                mc.AddProfile(new ProductProfile());
                // Master Data Profiles Configurations
                mc.AddProfile(new VendorProfile());
                mc.AddProfile(new CustomerProfile());
                mc.AddProfile(new StoreProfile());
            });
            // Call Service and pass mapper to it
            IMapper mapper = mapping.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
