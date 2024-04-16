﻿using Express_Management.Models.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Express_Management.Models.Configurations
{
    public class PurchaseReturnConfiguration : _BaseConfiguration<PurchaseReturn>
    {
        public override void Configure(EntityTypeBuilder<PurchaseReturn> builder)
        {
            base.Configure(builder);

            builder.Property(c => c.GoodsReceiveId).IsRequired();
            builder.Property(c => c.Number).HasMaxLength(100);
            builder.Property(c => c.Description).HasMaxLength(255);
        }
    }
}
