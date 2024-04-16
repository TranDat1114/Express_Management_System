using Express_Management.Applications.AdjustmentMinuss;
using Express_Management.Applications.AdjustmentPluss;
using Express_Management.Applications.ApplicationUsers;
using Express_Management.Applications.Companies;
using Express_Management.Applications.CustomerCategories;
using Express_Management.Applications.CustomerContacts;
using Express_Management.Applications.CustomerGroups;
using Express_Management.Applications.Customers;
using Express_Management.Applications.DeliveryOrders;
using Express_Management.Applications.GoodsReceives;
using Express_Management.Applications.InventoryTransactions;
using Express_Management.Applications.LogAnalytics;
using Express_Management.Applications.LogErrors;
using Express_Management.Applications.LogSessions;
using Express_Management.Applications.NumberSequences;
using Express_Management.Applications.ProductGroups;
using Express_Management.Applications.Products;
using Express_Management.Applications.PurchaseOrderItems;
using Express_Management.Applications.PurchaseOrders;
using Express_Management.Applications.PurchaseReturns;
using Express_Management.Applications.SalesOrderItems;
using Express_Management.Applications.SalesOrders;
using Express_Management.Applications.SalesReturns;
using Express_Management.Applications.Scrappings;
using Express_Management.Applications.StockCounts;
using Express_Management.Applications.Taxes;
using Express_Management.Applications.TransferIns;
using Express_Management.Applications.TransferOuts;
using Express_Management.Applications.UnitMeasures;
using Express_Management.Applications.VendorCategories;
using Express_Management.Applications.VendorContacts;
using Express_Management.Applications.VendorGroups;
using Express_Management.Applications.Vendors;
using Express_Management.Applications.Warehouses;
using Express_Management.Infrastructures.Countries;
using Express_Management.Infrastructures.Currencies;
using Express_Management.Infrastructures.Docs;
using Express_Management.Infrastructures.Emails;
using Express_Management.Infrastructures.Images;
using Express_Management.Infrastructures.Repositories;
using Express_Management.Infrastructures.TimeZones;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Express_Management
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAllCustomServices(this IServiceCollection services)
        {
            services.AddTransient<IActionContextAccessor, ActionContextAccessor>();
            services.AddScoped<IEmailSender, SMTPEmailService>();
            services.AddScoped<IFileImageService, FileImageService>();
            services.AddScoped<IFileDocumentService, FileDocumentService>();
            services.AddScoped<ITimeZoneService, TimeZoneService>();
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<ICurrencyService, CurrencyService>();
            services.AddScoped<IAuditColumnTransformer, AuditColumnTransformer>();
            services.AddScoped<CompanyService>();
            services.AddScoped<ApplicationUserService>();
            services.AddScoped<NumberSequenceService>();
            services.AddScoped<LogErrorService>();
            services.AddScoped<LogSessionService>();
            services.AddScoped<LogAnalyticService>();
            services.AddScoped<CustomerGroupService>();
            services.AddScoped<CustomerCategoryService>();
            services.AddScoped<VendorGroupService>();
            services.AddScoped<VendorCategoryService>();
            services.AddScoped<WarehouseService>();
            services.AddScoped<CustomerService>();
            services.AddScoped<VendorService>();
            services.AddScoped<UnitMeasureService>();
            services.AddScoped<ProductGroupService>();
            services.AddScoped<ProductService>();
            services.AddScoped<CustomerContactService>();
            services.AddScoped<VendorContactService>();
            services.AddScoped<TaxService>();
            services.AddScoped<SalesOrderService>();
            services.AddScoped<SalesOrderItemService>();
            services.AddScoped<PurchaseOrderService>();
            services.AddScoped<PurchaseOrderItemService>();
            services.AddScoped<InventoryTransactionService>();
            services.AddScoped<DeliveryOrderService>();
            services.AddScoped<GoodsReceiveService>();
            services.AddScoped<SalesReturnService>();
            services.AddScoped<PurchaseReturnService>();
            services.AddScoped<TransferInService>();
            services.AddScoped<TransferOutService>();
            services.AddScoped<StockCountService>();
            services.AddScoped<AdjustmentMinusService>();
            services.AddScoped<AdjustmentPlusService>();
            services.AddScoped<ScrappingService>();

            return services;
        }
    }
}
