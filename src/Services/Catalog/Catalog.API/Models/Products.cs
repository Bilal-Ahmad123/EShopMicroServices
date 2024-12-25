namespace Catalog.API.Models
{
    public class Products
    {
        public Guid id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public decimal Price { get; set; }
        public string ImageFile { get; set; } = default!;
        public List<string> Category { get; set; } = new();
    }
}
