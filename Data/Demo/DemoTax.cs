﻿using Express_Management.Applications.Taxes;
using Express_Management.Models.Entities;

namespace Express_Management.Data.Demo
{
    public static class DemoTax
    {
        public static async Task GenerateAsync(IServiceProvider services)
        {
            var service = services.GetRequiredService<TaxService>();

            await service.AddAsync(new Tax { Name = "NOTAX", Percentage = 0.0 });
            await service.AddAsync(new Tax { Name = "T10", Percentage = 10.0 });
            await service.AddAsync(new Tax { Name = "T15", Percentage = 15.0 });
            await service.AddAsync(new Tax { Name = "T20", Percentage = 20.0 });
        }
    }
}
