﻿using Express_Management.Applications.GoodsReceives;
using Express_Management.Applications.InventoryTransactions;
using Express_Management.Applications.NumberSequences;
using Express_Management.Applications.PurchaseOrderItems;
using Express_Management.Applications.PurchaseOrders;
using Express_Management.Applications.Warehouses;
using Express_Management.Models.Entities;
using Express_Management.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace Express_Management.Data.Demo
{
    public static class DemoGoodsReceive
    {
        public static async Task GenerateAsync(IServiceProvider services)
        {
            var goodsReceiveService = services.GetRequiredService<GoodsReceiveService>();
            var purchaseOrderService = services.GetRequiredService<PurchaseOrderService>();
            var purchaseOrderItemService = services.GetRequiredService<PurchaseOrderItemService>();
            var warehouseService = services.GetRequiredService<WarehouseService>();
            var numberSequenceService = services.GetRequiredService<NumberSequenceService>();
            var inventoryTransactionService = services.GetRequiredService<InventoryTransactionService>();
            Random random = new Random();
            int goodsReceiveStatusLength = Enum.GetNames(typeof(GoodsReceiveStatus)).Length;

            var purchaseOrders = purchaseOrderService
                .GetAll()
                .Where(x => x.OrderStatus >= PurchaseOrderStatus.Confirmed)
                .ToList();

            var warehouses = warehouseService
                .GetAll()
                .Where(x => x.SystemWarehouse == false)
                .Select(x => x.Id)
                .ToArray();

            foreach (var purchaseOrder in purchaseOrders)
            {
                var goodsReceive = new GoodsReceive
                {
                    Number = numberSequenceService.GenerateNumber(nameof(GoodsReceive), "", "GR"),
                    ReceiveDate = purchaseOrder.OrderDate?.AddDays(random.Next(1, 5)),
                    Status = (GoodsReceiveStatus)random.Next(0, goodsReceiveStatusLength),
                    PurchaseOrderId = purchaseOrder.Id,
                };
                await goodsReceiveService.AddAsync(goodsReceive);

                var items = purchaseOrderItemService
                    .GetAll()
                    .Include(x => x.Product)
                    .Where(x => x.PurchaseOrderId == purchaseOrder.Id && x.Product!.Physical == true).ToList();

                foreach (var item in items)
                {
                    var inventoryTransaction = new InventoryTransaction
                    {
                        ModuleId = goodsReceive.Id,
                        ModuleName = nameof(GoodsReceive),
                        ModuleCode = "GR",
                        ModuleNumber = goodsReceive.Number,
                        MovementDate = goodsReceive.ReceiveDate!.Value,
                        Status = (InventoryTransactionStatus)goodsReceive.Status,
                        Number = numberSequenceService.GenerateNumber(nameof(InventoryTransaction), "", "IVT"),
                        WarehouseId = DbInitializer.GetRandomValue(warehouses, random),
                        ProductId = item.ProductId,
                        Movement = item.Quantity!.Value
                    };

                    inventoryTransactionService.CalculateInvenTrans(inventoryTransaction);
                    await inventoryTransactionService.AddAsync(inventoryTransaction);
                }


            }

        }
    }
}
