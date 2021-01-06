using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess.Configurations
{
    public class TransmissionConfiguration : IEntityTypeConfiguration<Transmission>
    {
        public void Configure(EntityTypeBuilder<Transmission> builder)
        {
            builder.Property(t => t.Type)
                .IsRequired();
            builder.HasIndex(t => t.Type)
                .IsUnique();
            builder.Property(t => t.CreatedAt)
                .HasDefaultValueSql("GETDATE()");
        }
    }
}
