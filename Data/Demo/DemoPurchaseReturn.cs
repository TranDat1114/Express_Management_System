﻿using Express_Management.Applications.GoodsReceives;
using Express_Management.Applications.InventoryTransactions;
using Express_Management.Applications.NumberSequences;
using Express_Management.Applications.PurchaseReturns;
using Express_Management.Applications.Warehouses;
using Express_Management.Models.Entities;
using Express_Management.Models.Enums;

namespace Express_Management.Data.Demo
{
    public static class DemoPurchaseReturn
    {
        public static async Task GenerateAsync(IServiceProvider services)
        {
            var purchaseReturnService = services.GetRequiredService<PurchaseReturnService>();
            var goodsReceiveService = services.GetRequiredService<GoodsReceiveService>();
            var warehouseService = services.GetRequiredService<WarehouseService>();
            var numberSequenceService = services.GetRequiredService<NumberSequenceService>();
            var inventoryTransactionService = services.GetRequiredService<InventoryTransactionService>();
            Random random = new Random();
            int purchaseReturnStatusLength = Enum.GetNames(typeof(PurchaseReturnStatus)).Length;

            var goodsReceives = goodsReceiveService
                .GetAll()
                .Where(x => x.Status >= GoodsReceiveStatus.Confirmed)
                .ToList();

            var warehouses = warehouseService
                .GetAll()
                .Where(x => x.SystemWarehouse == false)
                .Select(x => x.Id)
                .ToArray();

            foreach (var goodsReceive in goodsReceives)
            {
                bool process = random.Next(2) == 0;

                if (process)
                {
                    continue;
                }

                var purchaseReturn = new PurchaseReturn
                {
                    Number = numberSequenceService.GenerateNumber(nameof(PurchaseReturn), "", "PRN"),
                    ReturnDate = goodsReceive.ReceiveDate?.AddDays(random.Next(1, 5)),
                    Status = (PurchaseReturnStatus)random.Next(0, purchaseReturnStatusLength),
                    GoodsReceiveId = goodsReceive.Id,
                };
                await purchaseReturnService.AddAsync(purchaseReturn);

                var items = inventoryTransactionService
                    .GetAll()
                    .Where(x => x.ModuleId == goodsReceive.Id && x.ModuleName == nameof(GoodsReceive))
                    .ToList();

                foreach (var item in items)
                {
                    var inventoryTransaction = new InventoryTransaction
                    {
                        ModuleId = purchaseReturn.Id,
                        ModuleName = nameof(PurchaseReturn),
                        ModuleCode = "PRN",
                        ModuleNumber = purchaseReturn.Number,
                        MovementDate = purchaseReturn.ReturnDate!.Value,
                        Status = (InventoryTransactionStatus)purchaseReturn.Status,
                        Number = numberSequenceService.GenerateNumber(nameof(InventoryTransaction), "", "IVT"),
                        WarehouseId = DbInitializer.GetRandomValue(warehouses, random),
                        ProductId = item.ProductId,
                        Movement = item.Movement
                    };

                    inventoryTransactionService.CalculateInvenTrans(inventoryTransaction);
                    await inventoryTransactionService.AddAsync(inventoryTransaction);
                }


            }

        }
    }
}
