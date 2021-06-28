using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess.Configurations
{
    public class CarEquipmentConfiguration : IEntityTypeConfiguration<Car_Equipment>
    {
        public void Configure(EntityTypeBuilder<Car_Equipment> builder)
        {
            builder.Property(x => x.CreatedAt)
                .HasDefaultValueSql("GETDATE()");
        }
    }
}
