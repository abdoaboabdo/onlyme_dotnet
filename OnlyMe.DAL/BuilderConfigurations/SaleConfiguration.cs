using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlyMe.DAL.Entities.Sales;

namespace OnlyMe.DAL.BuilderConfigurations
{
    internal class SaleConfiguration : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> entity)
        {
            entity.HasIndex(i => i.InventoryId).IsUnique();
            entity.Property(e => e.ProductSellingPrice).IsRequired();
            entity.Property(e => e.ProductSellingPrice).HasColumnType("decimal(18, 2)");

            entity.HasKey(e => new { e.InventoryId, e.CustomerInvoiceId });
            //entity.HasOne(i => i.Inventory)
            //      .WithMany(s => s.Sales)
            //      .HasForeignKey(i => i.InventoryId);
            //entity.HasOne(c => c.CustomerInvoice)
            //      .WithMany(s => s.Sales)
            //      .HasForeignKey(c => c.CustomerInvoiceId);
        }
    }
}
