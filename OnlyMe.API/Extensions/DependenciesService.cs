using Microsoft.Extensions.DependencyInjection;
using OnlyMe.Repository.UOW;
using OnlyMe.Services.Services.CategoriesService;
using OnlyMe.Services.Services.CustomersService;
using OnlyMe.Services.Services.ProductsService;
using OnlyMe.Services.Services.StoresService;
using OnlyMe.Services.Services.UsersService;
using OnlyMe.Services.Services.VarietiesService;
using OnlyMe.Services.Services.VendorService;

namespace OnlyMe.API.Extensions
{
    public static class DependenciesService
    {
        public static void ConfigureDependencies(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserService, UserService>();

            //LookUps
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IVarietyService, VarietyService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IStoreService, StoreService>();

            // Master Data Profiles Configurations
            services.AddScoped<IVendorService, VendorService>();
            services.AddScoped<ICustomerService, CustomerService>();
            
        }
    }
}
