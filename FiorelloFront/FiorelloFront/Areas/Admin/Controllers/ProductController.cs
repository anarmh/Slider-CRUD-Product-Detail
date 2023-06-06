using FiorelloFront.Areas.Admin.ViewModels.Product;
using FiorelloFront.Models;
using FiorelloFront.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FiorelloFront.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
          var prodcuts=await _productService.GetAllWithIncludesAsync();

           return View(_productService.GetMappedDatas(await _productService.GetAllWithIncludesAsync()));
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            if (id is null) return BadRequest();

            Product product = await _productService.GetWithIncludeAsync((int)id);
            if(product is null) return NotFound();

           return View(_productService.GetMappedData(product));
        }
    }
}
