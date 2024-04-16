using Express_Management.Applications.UnitMeasures;
using Express_Management.Models.Entities;

namespace Express_Management.Data.Demo
{
    public static class DemoUnitMeasure
    {
        public static async Task GenerateAsync(IServiceProvider services)
        {
            var service = services.GetRequiredService<UnitMeasureService>();

            await service.AddAsync(new UnitMeasure { Name = "m" });
            await service.AddAsync(new UnitMeasure { Name = "kg" });
            await service.AddAsync(new UnitMeasure { Name = "hour" });
            await service.AddAsync(new UnitMeasure { Name = "unit" });
        }
    }
}
