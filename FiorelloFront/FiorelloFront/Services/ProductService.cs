using FiorelloFront.Areas.Admin.ViewModels.Product;
using FiorelloFront.Data;
using FiorelloFront.Models;
using FiorelloFront.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FiorelloFront.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;
        public ProductService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products.Include(m => m.ProductImages).Take(8).Where(m => !m.SoftDelete).ToListAsync();
        }

        public async Task<List<Product>> GetAllWithIncludesAsync()
        {
            return await _context.Products.Include(m => m.ProductImages).Include(m => m.Category).Include(m => m.Discount).ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int? id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<Product> GetByIdImagesAsync(int? id)
        {
            return await _context.Products.Include(m => m.ProductImages).FirstOrDefaultAsync(m => m.Id == id);
        }


        public List<ProductVM> GetMappedDatas(List<Product> products)
        {
            List<ProductVM> list = new();
            foreach (var product in products)
            {
                list.Add(new ProductVM
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    CategoryName = product.Category.Name,
                    Image = product.ProductImages.Where(m => m.IsMain).FirstOrDefault().Image,
                    Discount = product.Discount.Name,
                });

            }
            return list;
        }


        public ProductDetailVM GetMappedData(Product product)
        {
          
            return new ProductDetailVM
            {
                Name = product.Name,
                Price = product.Price.ToString("0.##"),
                CategoryName = product.Category.Name,
                Discount = product.Discount.Name,
                Images = product.ProductImages.Select(m => m.Image)
            };
        }

        public async Task<Product> GetWithIncludeAsync(int id)
        {
            return await _context.Products.Include(m => m.ProductImages).Include(m => m.Category).Include(m => m.Discount).FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}
