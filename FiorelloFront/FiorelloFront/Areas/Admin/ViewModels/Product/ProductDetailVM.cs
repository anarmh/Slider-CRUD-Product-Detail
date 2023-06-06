namespace FiorelloFront.Areas.Admin.ViewModels.Product
{
    public class ProductDetailVM
    {
        public string Name { get; set; }
        public string Price { get; set; }
        public string CategoryName { get; set; }
        public IEnumerable<string> Images { get; set; }
        public string Discount { get; set; }
    }
}
