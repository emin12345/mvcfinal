using riode.Models;
using System.ComponentModel.DataAnnotations;

namespace riode.ViewModel
{
    public class ProductViewModel
    {
        public string Title { get; set; } = null!;
        public double Price { get; set; }
        public double OldPrice { get; set; }
        [Range(0, 5, ErrorMessage = "0-5 arasi olmalidir")]
        public double Rating { get; set; }
        public double SKU { get; set; }
        public bool isStocked { get; init; }
        public string Description { get; set; } = null!;
        public string Features { get; set; } = null!;
        public string Material { get; set; } = null!;
        public string ClaimedSize { get; set; } = null!;
        public string RecommendedUse { get; set; } = null!;
        public string Manufacturer { get; set; } = null!;

        public int BrandId { get; set; }
        public Brand Brand { get; set; } = null!;

        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;
        public IFormFile[] Images { get; set; } = null!;
    }
}
