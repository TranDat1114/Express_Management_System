﻿using Express_Management.Models.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Express_Management.Models.Configurations
{
    public class DeliveryOrderConfiguration : _BaseConfiguration<DeliveryOrder>
    {
        public override void Configure(EntityTypeBuilder<DeliveryOrder> builder)
        {
            base.Configure(builder);

            builder.Property(c => c.SalesOrderId).IsRequired();
            builder.Property(c => c.Number).HasMaxLength(100);
            builder.Property(c => c.Description).HasMaxLength(255);
        }
    }
}
