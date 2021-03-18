using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Namotion.Reflection;
using OnlyMe.DAL.Entities.Customers;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlyMe.DAL.BuilderConfigurations
{
    internal class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> entity)
        {
            entity.Property(e => e.Name).IsRequired();
            entity.Property(e => e.Name).HasMaxLength(250);
            entity.HasIndex(e => e.MobileNumber).IsUnique();
            entity.Property(e => e.AddressDetails).HasMaxLength(500);
        }
    }
}
