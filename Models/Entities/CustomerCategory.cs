using Express_Management.Models.Contracts;

namespace Express_Management.Models.Entities
{
    public class CustomerCategory : _Base
    {
        public CustomerCategory() { }
        public required string Name { get; set; }
        public string? Description { get; set; }
    }
}
