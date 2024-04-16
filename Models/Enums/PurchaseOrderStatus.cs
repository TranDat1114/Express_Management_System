using System.ComponentModel;

namespace Express_Management.Models.Enums
{
    public enum PurchaseOrderStatus
    {
        [Description("Draft")]
        Draft = 0,
        [Description("Cancelled")]
        Cancelled = 1,
        [Description("Confirmed")]
        Confirmed = 2,
        [Description("Archived")]
        Archived = 3
    }
}
