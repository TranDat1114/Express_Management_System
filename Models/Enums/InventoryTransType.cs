using System.ComponentModel;

namespace Express_Management.Models.Enums
{
    public enum InventoryTransType
    {
        [Description("In")]
        In = 1,
        [Description("Out")]
        Out = -1,
    }
}
