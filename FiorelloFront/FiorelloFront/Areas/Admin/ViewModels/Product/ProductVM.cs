using FiorelloFront.Models;

namespace FiorelloFront.Areas.Admin.ViewModels.Product
{
    public class ProductVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string CategoryName { get; set; }
        public string Image { get; set; }
        public string Discount { get; set; }

    }
}
