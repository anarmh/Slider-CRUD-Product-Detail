using System.ComponentModel.DataAnnotations;

namespace FiorelloFront.Areas.Admin.ViewModels.Category
{
    public class CategoryCreateVM
    {
        [Required(ErrorMessage ="Dont be empty")]
        [MaxLength(20)]
        public string Name { get; set; }
    }
}
