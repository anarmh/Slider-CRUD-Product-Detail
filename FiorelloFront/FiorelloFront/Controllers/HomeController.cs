
using FiorelloFront.Data;
using FiorelloFront.Models;
using FiorelloFront.Services.Interfaces;
using FiorelloFront.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Linq;

namespace FiorelloFront.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IProductService _productService;

        public HomeController(AppDbContext context,IProductService productService)
        {
            _context = context;
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
          
            IEnumerable<Blog> blogs=await _context.Blogs.Where(m => !m.SoftDelete).OrderByDescending(m=>m.Id).Take(3).ToListAsync();
            IEnumerable<Category> categories=await _context.Categories.Where(m => !m.SoftDelete).ToListAsync();
            IEnumerable<Product> products =await _productService.GetAllAsync();
            About about=await _context.Abouts.Where(m => !m.SoftDelete).FirstOrDefaultAsync();
            IEnumerable<FlowersExpert> flowersExperts = await _context.FlowersExperts.Where(m => !m.SoftDelete).ToListAsync();
            IEnumerable<Say> says = await _context.Says.Where(m => !m.SoftDelete).ToListAsync();
            IEnumerable<Instagram> instagrams = await _context.Instagrams.Where(m => !m.SoftDelete).ToListAsync();
            HomeVM model = new()
            {
                
                Blogs=blogs,
                Categories= categories,
                Products= products,
               About= about,
               FlowersExperts= flowersExperts,
               Says= says,
               Instagrams= instagrams
            };

            return View(model);
        }

        //[HttpPost]
        //public async Task<IActionResult> Addbasket(int? id)
        //{
        //    if (id is null) return BadRequest();
        //    Product product = await _context.Products.FindAsync(id);

        //    if (product == null) return NotFound();

        //    List<BasketVM> basket = GetbasketDatas();

        //    AddProductToBasket(basket, product);

        //    return RedirectToAction(nameof(Index));
        //}



        //private List<BasketVM> GetbasketDatas()
        //{
        //    List<BasketVM> basket;
        //    if (_accessor.HttpContext.Request.Cookies["basket"] != null)
        //    {
        //        basket = JsonConvert.DeserializeObject<List<BasketVM>>(_accessor.HttpContext.Request.Cookies["basket"]);
        //    }
        //    else
        //    {
        //        basket = new List<BasketVM>();
        //    }
        //    return basket;

        //}


        //private void AddProductToBasket(List<BasketVM> basket, Product product)
        //{
        //    BasketVM existProduct = basket.FirstOrDefault(m => m.Id == product.Id);

        //    if (existProduct == null)
        //    {
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


        //    _accessor.HttpContext.Response.Cookies.Append("basket", JsonConvert.SerializeObject(basket));
        //}






    }
}