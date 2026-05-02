using System.Collections.Generic;

namespace SportShop.Model
{
    public class Color
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;

        // Navigation
        public ICollection<ProductVariant> ProductVariants { get; set; } = new List<ProductVariant>();
    }
}
