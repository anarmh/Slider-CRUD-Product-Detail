
using FiorelloFront.Data;
using FiorelloFront.Models;
using FiorelloFront.Services.Interfaces;
using FiorelloFront.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace FiorelloFront.ViewComponents
{
    public class SliderViewComponent:ViewComponent
    {
        private readonly AppDbContext _context;
        private readonly ISliderService _sliderService;

        public SliderViewComponent(AppDbContext context,ISliderService sliderService)
        {
            _context = context;
            _sliderService = sliderService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            IEnumerable<Slider> sliders = await _sliderService.GetAllByStatusAsync();
            SliderInfo sliderInfo = await _context.SliderInfos.Where(m => !m.SoftDelete).FirstOrDefaultAsync();

            SliderVM model = new()
            {
                SliderInfo = sliderInfo,
                Sliders = sliders
            };

            return await Task.FromResult(View(model)); 
        }
    }
}
