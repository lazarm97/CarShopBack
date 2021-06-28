using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess.Configurations
{
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.Property(c => c.CurrentKm)
                .IsRequired();
            builder.Property(c => c.Cubic)
                .IsRequired();
            builder.Property(c => c.PowerKw)
                .IsRequired();
            builder.Property(c => c.Price)
                .IsRequired();
            builder.Property(c => c.Vin)
                .IsRequired();
            builder.HasIndex(c => c.Vin)
                .IsUnique();
            builder.Property(c => c.Note)
                .IsRequired();
            builder.Property(c => c.CreatedAt)
                .HasDefaultValueSql("GETDATE()");
            
        }
    }
}
