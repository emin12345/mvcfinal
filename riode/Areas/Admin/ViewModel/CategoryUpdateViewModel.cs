using System.ComponentModel.DataAnnotations;

namespace riode.Areas.Admin.ViewModel
{
    public class CategoryUpdateViewModel
    {
        [Required]
        public string CategoryName { get; set; }
        public IFormFile? Image { get; set; }
    }
}
