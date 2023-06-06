using FiorelloFront.Areas.Admin.ViewModels.Product;
using FiorelloFront.Models;

namespace FiorelloFront.Services.Interfaces
{
    public interface IProductService
    {
        public Task<IEnumerable<Product>> GetAllAsync();
        public Task<List<Product>> GetAllWithIncludesAsync();
        public Task<Product> GetByIdAsync(int? id);
        public Task<Product> GetByIdImagesAsync(int? id);
        public List<ProductVM> GetMappedDatas(List<Product> products);
        public Task<Product> GetWithIncludeAsync(int id);
        public ProductDetailVM GetMappedData(Product product);
    }
}
