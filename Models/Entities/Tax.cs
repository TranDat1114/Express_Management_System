using Express_Management.Models.Contracts;

namespace Express_Management.Models.Entities
{
    public class Tax : _Base
    {
        public Tax() { }
        public string? Name { get; set; }
        public double? Percentage { get; set; }
        public string? Description { get; set; }
    }
}
