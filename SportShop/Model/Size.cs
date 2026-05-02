using System.Collections.Generic;

namespace SportShop.Model
{
    public class Size
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool? IsActive { get; set; }

        // Navigation
        public List<ProductVariant> ProductVariants { get; set; } = new List<ProductVariant>();

        public Size() { }
        public Size(int id, string name) { Id = id; Name = name; }
    }
}