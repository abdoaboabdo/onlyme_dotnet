using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Namotion.Reflection;
using OnlyMe.DAL.Entities.Categories;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlyMe.DAL.BuilderConfigurations
{
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> entity)
        {
            entity.Property(e => e.Name).IsRequired().HasMaxLength(250);
            entity.HasIndex(e => e.Name).IsUnique();
        }
    }
}
