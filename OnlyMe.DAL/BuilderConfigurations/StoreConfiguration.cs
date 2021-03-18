using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlyMe.DAL.Entities.Stores;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlyMe.DAL.BuilderConfigurations
{
    internal class StoreConfiguration : IEntityTypeConfiguration<Store>
    {
        public void Configure(EntityTypeBuilder<Store> entity)
        {
            entity.Property(e => e.Code).IsRequired().HasMaxLength(250);
            entity.HasIndex(e => e.Code).IsUnique();
            entity.Property(e => e.Name).IsRequired();
            entity.Property(e => e.Name).HasMaxLength(75);
        }
    }
}
