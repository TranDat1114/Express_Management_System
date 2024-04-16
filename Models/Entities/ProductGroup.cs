using Express_Management.Models.Contracts;

namespace Express_Management.Models.Entities
{
    public class ProductGroup : _Base
    {
        public ProductGroup() { }
        public required string Name { get; set; }
        public string? Description { get; set; }
    }
}
