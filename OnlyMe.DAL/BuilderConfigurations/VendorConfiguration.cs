using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlyMe.DAL.Entities.Vendors;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlyMe.DAL.BuilderConfigurations
{
    internal class VendorConfiguration : IEntityTypeConfiguration<Vendor>
    {
        public void Configure(EntityTypeBuilder<Vendor> entity)
        {
            entity.Property(e => e.Name).IsRequired().HasMaxLength(250);
            entity.HasIndex(e => e.Email).IsUnique();
            entity.HasIndex(e => e.MobileNumber).IsUnique();
            entity.HasIndex(e => e.PhoneNumber).IsUnique();
            entity.Property(e => e.AddressDetails).HasMaxLength(500);
        }
    }
}
