using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlyMe.DAL.Entities.Varieties;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlyMe.DAL.BuilderConfigurations
{
    internal class VarietyConfiguration : IEntityTypeConfiguration<Variety>
    {
        public void Configure(EntityTypeBuilder<Variety> entity)
        {
            entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
        }
    }
}
