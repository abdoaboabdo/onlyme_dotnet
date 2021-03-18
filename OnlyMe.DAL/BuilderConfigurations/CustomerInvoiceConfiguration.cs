using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlyMe.DAL.Entities.CustomerInvoices;

namespace OnlyMe.DAL.BuilderConfigurations
{
    internal class CustomerInvoiceConfiguration : IEntityTypeConfiguration<CustomerInvoice>
    {
        public void Configure(EntityTypeBuilder<CustomerInvoice> entity)
        {
            entity.Property(e => e.Note).HasMaxLength(250);
            entity.HasIndex(e => e.Code).IsUnique();
            entity.Property(e => e.IsPaied)
                .IsRequired()
                .HasDefaultValue(true);
        }
    }
}
