﻿using Express_Management.Models.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Express_Management.Models.Configurations
{
    public class NumberSequenceConfiguration : _BaseConfiguration<NumberSequence>
    {
        public override void Configure(EntityTypeBuilder<NumberSequence> builder)
        {
            base.Configure(builder);

            builder.Property(c => c.EntityName).HasMaxLength(100).IsRequired();
            builder.Property(c => c.Prefix).HasMaxLength(5);
            builder.Property(c => c.Suffix).HasMaxLength(5);
        }


    }
}
