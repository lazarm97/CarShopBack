using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess.Configurations
{
    public class YearOfManufactureConfiguration : IEntityTypeConfiguration<YearOfManufacture>
    {
        public void Configure(EntityTypeBuilder<YearOfManufacture> builder)
        {
            builder.Property(y => y.Year)
                .IsRequired();
            builder.HasIndex(y => y.Year)
                .IsUnique();
        }
    }
}
