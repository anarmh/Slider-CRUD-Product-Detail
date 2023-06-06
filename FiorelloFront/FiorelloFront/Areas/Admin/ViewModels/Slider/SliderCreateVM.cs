using System.ComponentModel.DataAnnotations;

namespace FiorelloFront.Areas.Admin.ViewModels.Slider
{
    public class SliderCreateVM
    {
        [Required]
        public List<IFormFile> Images { get; set; }
    }
}
