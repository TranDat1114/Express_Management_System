using Express_Management.Models.Contracts;
using Express_Management.Models.Enums;

namespace Express_Management.Models.Entities
{
    public class StockCount : _Base
    {
        public StockCount() { }
        public string? Number { get; set; }
        public DateTime? CountDate { get; set; }
        public StockCountStatus? Status { get; set; }
        public string? Description { get; set; }
        public required int WarehouseId { get; set; }
        public Warehouse? Warehouse { get; set; }
    }
}
