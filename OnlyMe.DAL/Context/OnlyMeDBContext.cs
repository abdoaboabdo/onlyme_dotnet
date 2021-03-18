using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using OnlyMe.DAL.BuilderConfigurations;
using OnlyMe.DAL.Entities;
using OnlyMe.DAL.Entities.Categories;
using OnlyMe.DAL.Entities.CustomerInvoices;
using OnlyMe.DAL.Entities.Customers;
using OnlyMe.DAL.Entities.Inventories;
using OnlyMe.DAL.Entities.Products;
using OnlyMe.DAL.Entities.Sales;
using OnlyMe.DAL.Entities.Stores;
using OnlyMe.DAL.Entities.Varieties;
using OnlyMe.DAL.Entities.VendorInvoices;
using OnlyMe.DAL.Entities.Vendors;
using System.Diagnostics.CodeAnalysis;

namespace OnlyMe.DAL.Context
{
    public partial class OnlyMeDBContext: ApiAuthorizationDbContext<ApplicationUser>
    {

        // Vendor
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<VendorInvoice> VendorInvoices { get; set; }
        public DbSet<Inventory> Inventories { get; set; }

        // Customer
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerInvoice> CustomerInvoices { get; set; }
        public DbSet<Sale> Sales { get; set; }

        // Categories , Varieties
        public DbSet<Category> Categories { get; set; }
        public DbSet<Variety> Varieties { get; set; }

        // 
        public DbSet<Store> Stores { get; set; }

        public OnlyMeDBContext([NotNull] DbContextOptions<OnlyMeDBContext> options,
             IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            OnModelCreatingPartial(modelBuilder);


        }
    }

    public partial class OnlyMeDBContext
    {
        public void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerInvoiceConfiguration());
            modelBuilder.ApplyConfiguration(new InventoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new SaleConfiguration());
            modelBuilder.ApplyConfiguration(new StoreConfiguration());
            modelBuilder.ApplyConfiguration(new VarietyConfiguration());
            modelBuilder.ApplyConfiguration(new VendorConfiguration());
            modelBuilder.ApplyConfiguration(new VendorInvoiceConfiguration());
        }

    }
}
