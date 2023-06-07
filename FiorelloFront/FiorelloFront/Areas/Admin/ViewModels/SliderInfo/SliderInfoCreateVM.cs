using System.ComponentModel.DataAnnotations;

namespace FiorelloFront.Areas.Admin.ViewModels.SliderInfo
{
    public class SliderInfoCreateVM
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public IFormFile SignImage { get; set; }
    }
}
