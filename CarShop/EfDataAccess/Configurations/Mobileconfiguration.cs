using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess.Configurations
{
    public class Mobileconfiguration : IEntityTypeConfiguration<Mobile>
    {
        public void Configure(EntityTypeBuilder<Mobile> builder)
        {
            builder.Property(m => m.Number)
                .IsRequired();
            builder.Property(m => m.CreatedAt)
                .HasDefaultValueSql("GETDATE()");
        }
    }
}
