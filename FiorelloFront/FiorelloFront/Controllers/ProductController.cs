using FiorelloFront.Data;
using FiorelloFront.Models;
using FiorelloFront.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FiorelloFront.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int? id)
        {
            if (id is null) return BadRequest();
            Product product = await _context.Products.Include(m=>m.Discount).Include(m=>m.ProductImages).Include(m=>m.Category).Where(m=>!m.SoftDelete).FirstOrDefaultAsync(x => x.Id == id);

            if (product is null) return NotFound();

            ProductDetailVM model = new()
            {
                Id = product.Id,
                Name = product.Name,
                ActualPrice = product.Price,
                DiscountPrice = product.Price - (product.Price * product.Discount.Percent) / 100,
                Percent= product.Discount.Percent,
                ProductImages = product.ProductImages.ToList()
            };
           
            return View(model);
        }
    }
}
