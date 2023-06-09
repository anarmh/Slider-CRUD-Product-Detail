using System.ComponentModel.DataAnnotations;

namespace FiorelloFront.Areas.Admin.ViewModels.SliderInfo
{
    public class SliderInfoEditVM
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string SignImage { get; set; }
        
        public string NewTitle { get; set; }
       
        public string NewDescription { get; set; }
      
        public IFormFile NewSignImage { get; set; }
    }
}
