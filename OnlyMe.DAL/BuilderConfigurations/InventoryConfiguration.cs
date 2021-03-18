using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlyMe.DAL.Entities.Inventories;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlyMe.DAL.BuilderConfigurations
{
    internal class InventoryConfiguration : IEntityTypeConfiguration<Inventory>
    {
        public void Configure(EntityTypeBuilder<Inventory> entity)
        {
            entity.Property(e => e.Code).IsRequired().HasMaxLength(250);
            entity.HasIndex(e => e.Code).IsUnique();
            entity.Property(e => e.Purchasingprice).IsRequired();
            entity.Property(e => e.Purchasingprice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ExpectedSellingPrice).HasColumnType("decimal(18, 2)");
        }
    }
}
