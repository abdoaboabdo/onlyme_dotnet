using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlyMe.DAL.Entities.VendorInvoices;

namespace OnlyMe.DAL.BuilderConfigurations
{
    internal class VendorInvoiceConfiguration : IEntityTypeConfiguration<VendorInvoice>
    {
        public void Configure(EntityTypeBuilder<VendorInvoice> entity)
        {
            entity.HasIndex(e => e.Code).IsUnique();
        }
    }
}
