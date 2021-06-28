using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
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
            builder.Property(a => a.Username)
                .HasMaxLength(30)
                .IsRequired();
            builder.HasIndex(a => a.Username)
                .IsUnique();
            builder.Property(a => a.Password)
                .HasMaxLength(255)
                .IsRequired();
            builder.Property(a => a.CreatedAt)
                .HasDefaultValueSql("GETDATE()");
        }
    }
}
