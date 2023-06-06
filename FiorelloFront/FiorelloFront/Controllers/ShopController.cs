using FiorelloFront.Data;
using FiorelloFront.Models;
using FiorelloFront.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace FiorelloFront.Controllers
{
    public class ShopController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _accessor;

        public ShopController(AppDbContext context, IHttpContextAccessor accessor)
        {
            _context = context;
            _accessor = accessor;
        }
        public async Task<IActionResult> Index()
        {

            IEnumerable<Product> products = await _context.Products.Include(m => m.ProductImages).Where(m => !m.SoftDelete).Take(4).ToListAsync();

            int count = await _context.Products.Where(m => !m.SoftDelete).CountAsync();

            ViewBag.Count=count;
            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> ShowMoreOrLess(int skip)
        {
            IEnumerable<Product> products = await _context.Products.Include(m => m.ProductImages).Where(m => !m.SoftDelete).Skip(skip).Take(4).ToListAsync();
            return PartialView("_ProductsPartial",products);
        }
        //[HttpPost]
        //public async Task<IActionResult> AddBasket(int? id)
        //{
        //    if (id is null) return BadRequest();

        //    Product product= await _context.Products.FindAsync(id);

        //    if (product == null) return NotFound();

        //    List<BasketVM> basket;

        //    if (_accessor.HttpContext.Request.Cookies["basket"] != null)
        //    {
        //        basket = JsonConvert.DeserializeObject<List<BasketVM>>(_accessor.HttpContext.Request.Cookies["basket"]);
        //    }
        //    else
        //    {
        //        basket = new List<BasketVM>();
        //    }

        //    BasketVM existProduct=basket.FirstOrDefault(m=>m.Id==product.Id);

        //    if (existProduct == null) {
        //        basket.Add(new BasketVM
        //        {
        //            Id = product.Id,
        //            Count = 1
        //        });
        //    }
        //    else
        //    {
        //        existProduct.Count++;
        //    }
           

        //    _accessor.HttpContext.Response.Cookies.Append("basket",JsonConvert.SerializeObject(basket));

        //    return RedirectToAction(nameof(Index));
        //}
    }
}
