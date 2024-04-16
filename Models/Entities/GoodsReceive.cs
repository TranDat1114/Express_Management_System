using Express_Management.Models.Contracts;
using Express_Management.Models.Enums;

namespace Express_Management.Models.Entities
{
    public class GoodsReceive : _Base
    {
        public GoodsReceive() { }
        public string? Number { get; set; }
        public DateTime? ReceiveDate { get; set; }
        public GoodsReceiveStatus? Status { get; set; }
        public string? Description { get; set; }
        public required int PurchaseOrderId { get; set; }
        public PurchaseOrder? PurchaseOrder { get; set; }
    }
}
