using FiorelloFront.Areas.Admin.ViewModels.Product;
using FiorelloFront.Helpers;
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
        public async Task<IActionResult> Index(int page=1,int take=3)
        {
            var paginateDatas = await _productService.GetPaginateDatasAsync(page,take);

            int pageCount= await GetCountAsync(take);

            if (page > pageCount)
            {
                return NotFound();
            }
            
            List<ProductVM> mappedDatas = _productService.GetMappedDatas(paginateDatas);

            Paginate<ProductVM> datas = new(mappedDatas,page,pageCount);

           return View(datas);
        }

        private async Task<int> GetCountAsync(int take)
        {
            int count = await _productService.GetCountAsync();
            decimal result =Math.Ceiling((decimal)count / take);
            return (int)result;
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
