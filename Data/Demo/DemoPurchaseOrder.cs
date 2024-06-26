﻿using Express_Management.Applications.NumberSequences;
using Express_Management.Applications.Products;
using Express_Management.Applications.PurchaseOrderItems;
using Express_Management.Applications.PurchaseOrders;
using Express_Management.Applications.Taxes;
using Express_Management.Applications.Vendors;
using Express_Management.Models.Entities;
using Express_Management.Models.Enums;

namespace Express_Management.Data.Demo
{
    public static class DemoPurchaseOrder
    {
        public static async Task GenerateAsync(IServiceProvider services)
        {
            var purchaseOrderService = services.GetRequiredService<PurchaseOrderService>();
            var purchaseOrderItemService = services.GetRequiredService<PurchaseOrderItemService>();
            var vendorService = services.GetRequiredService<VendorService>();
            var taxSerice = services.GetRequiredService<TaxService>();
            var productService = services.GetRequiredService<ProductService>();
            var numberSequenceService = services.GetRequiredService<NumberSequenceService>();

            Random random = new Random();
            int orderStatusLength = Enum.GetNames(typeof(PurchaseOrderStatus)).Length;
            var vendors = vendorService.GetAll().Select(x => x.Id).ToArray();
            var taxes = taxSerice.GetAll().Select(x => x.Id).ToArray();
            var products = productService.GetAll().ToList();

            var dateFinish = DateTime.Now;
            var dateStart = new DateTime(dateFinish.AddMonths(-12).Year, dateFinish.AddMonths(-12).Month, 1);

            for (DateTime date = dateStart; date < dateFinish; date = date.AddMonths(1))
            {
                DateTime[] transactionDates = DbInitializer.GetRandomDays(date.Year, date.Month, 6);

                foreach (DateTime transDate in transactionDates)
                {
                    var purchaseOrder = new PurchaseOrder
                    {
                        Number = numberSequenceService.GenerateNumber(nameof(PurchaseOrder), "", "PO"),
                        OrderDate = transDate,
                        OrderStatus = (PurchaseOrderStatus)random.Next(0, orderStatusLength),
                        VendorId = DbInitializer.GetRandomValue(vendors, random),
                        TaxId = DbInitializer.GetRandomValue(taxes, random),
                    };
                    await purchaseOrderService.AddAsync(purchaseOrder);

                    int numberOfProducts = random.Next(3, 6);
                    for (int i = 0; i < numberOfProducts; i++)
                    {
                        var product = products[random.Next(0, products.Count())];
                        var purchaseOrderItem = new PurchaseOrderItem
                        {
                            PurchaseOrderId = purchaseOrder.Id,
                            ProductId = product.Id,
                            Summary = product.Number,
                            UnitPrice = product.UnitPrice,
                            Quantity = random.Next(20, 50),
                        };
                        purchaseOrderItem.RecalculateTotal();
                        await purchaseOrderItemService.AddAsync(purchaseOrderItem);
                    }


                }
            }
        }
    }
}
