using Express_Management.Models.Contracts;
using Express_Management.Models.Enums;

namespace Express_Management.Models.Entities
{
    public class SalesReturn : _Base
    {
        public SalesReturn() { }
        public string? Number { get; set; }
        public DateTime? ReturnDate { get; set; }
        public SalesReturnStatus? Status { get; set; }
        public string? Description { get; set; }
        public required int DeliveryOrderId { get; set; }
        public DeliveryOrder? DeliveryOrder { get; set; }
    }
}
