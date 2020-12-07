using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess.Configurations
{
    public class AdminConfiguration : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            builder.Property(a => a.FirstName)
                .HasMaxLength(30)
                .IsRequired();
            builder.Property(a => a.LastName)
                .HasMaxLength(30)
                .IsRequired();
            builder.Property(a => a.Email)
                .IsRequired();
            builder.HasIndex(a => a.Email)
                .IsUnique();
            builder.Property(a => a.Password)
                .IsRequired();
            builder.Property(a => a.CreatedAt)
                .HasDefaultValueSql("GETDATE()");
        }
    }
}
