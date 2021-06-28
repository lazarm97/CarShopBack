using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.Property(a => a.Id)
                .IsRequired();
            builder.Property(a => a.Name)
                .HasMaxLength(30)
                .IsRequired();
            builder.HasIndex(a => a.Name)
                .IsUnique();
        }
    }
}
