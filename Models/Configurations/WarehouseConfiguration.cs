using Express_Management.Models.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Express_Management.Models.Configurations
{
    public class WarehouseConfiguration : _BaseConfiguration<Warehouse>
    {
        public override void Configure(EntityTypeBuilder<Warehouse> builder)
        {
            base.Configure(builder);

            builder.Property(c => c.Name).IsRequired().HasMaxLength(100);
            builder.Property(c => c.Description).HasMaxLength(255);
        }
    }
}
