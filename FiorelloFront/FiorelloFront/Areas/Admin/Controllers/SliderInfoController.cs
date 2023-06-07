using FiorelloFront.Areas.Admin.ViewModels.SliderInfo;
using FiorelloFront.Helpers;
using FiorelloFront.Models;
using FiorelloFront.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FiorelloFront.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class SliderInfoController : Controller
    {
        private readonly ISliderInfoService _sliderInfoService;
        private readonly IWebHostEnvironment _env;

        public SliderInfoController(ISliderInfoService sliderInfoService, IWebHostEnvironment env)
        {
            _sliderInfoService = sliderInfoService;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            List<SliderInfoVM> list = new();
            List<SliderInfo> sliderInfos= await _sliderInfoService.GetAllDataAsync();


            foreach (var item in sliderInfos)
            {
                SliderInfoVM model = new()
                {
                    Id = item.Id,
                    Title = item.Title,
                    Description = item.Description,
                    SignImage = item.SignImage,
                };
                list.Add(model);
            }
           

            return View(list);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SliderInfoCreateVM request)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }

            
            
            if (request.SignImage.CheckFileType("Image/"))
            {
               ModelState.AddModelError("SignImage", "Please select only image file");
                return View();
            }
            if (request.SignImage.CheckFileSize(200))
            {
                ModelState.AddModelError("SignImage", "Image size must be max 200KB");
                return View();
            }

            await _sliderInfoService.CreateAsync(request.SignImage,request.Title,request.Description);

            return RedirectToAction(nameof(Index));

        }
    }
}
