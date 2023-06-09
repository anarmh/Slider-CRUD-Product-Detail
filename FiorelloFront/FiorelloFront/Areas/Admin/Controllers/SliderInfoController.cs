using FiorelloFront.Areas.Admin.ViewModels.Slider;
using FiorelloFront.Areas.Admin.ViewModels.SliderInfo;
using FiorelloFront.Helpers;
using FiorelloFront.Models;
using FiorelloFront.Services;
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

            
            
            if (!request.SignImage.CheckFileType("image/"))
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

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _sliderInfoService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null) return BadRequest();

            SliderInfo sliderInfo = await _sliderInfoService.GetByIdAsync((int)id);

           if(sliderInfo == null) return NotFound();

            SliderInfoEditVM model = new()
            {
                Title = sliderInfo.Title,
                Description = sliderInfo.Description,
                SignImage = sliderInfo.SignImage,
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SliderInfoEditVM request, int? id)
        {
            if (id is null) return BadRequest();

            SliderInfo dbSliderInfo = await _sliderInfoService.GetByIdAsync((int)id);

            if (dbSliderInfo is null) return NotFound();

           

            if (request.NewSignImage is null) return RedirectToAction(nameof(Index));

            if (!request.NewSignImage.CheckFileType("image/"))
            {
                ModelState.AddModelError("NewSignImage", "Please select only image file");
                request.SignImage = dbSliderInfo.SignImage;
                return View(request);
            }

            if (request.NewSignImage.CheckFileSize(200))
            {
                ModelState.AddModelError("NewSignImage", "Image size must be max 200KB");
                request.SignImage = dbSliderInfo.SignImage;
                return View(request);
            }

            await _sliderInfoService.EditAsync(dbSliderInfo, request.NewSignImage,request.NewDescription,request.NewTitle);


            return RedirectToAction(nameof(Index));
        }
    }
}
