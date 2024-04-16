using Express_Management.Models.Contracts;
using Express_Management.Models.Enums;

namespace Express_Management.Models.Entities
{
    public class AdjustmentMinus : _Base
    {
        public AdjustmentMinus() { }
        public string? Number { get; set; }
        public DateTime? AdjustmentDate { get; set; }
        public AdjustmentStatus? Status { get; set; }
        public string? Description { get; set; }
    }
}
