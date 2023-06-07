using FiorelloFront.Areas.Admin.ViewModels.Slider;
using FiorelloFront.Data;
using FiorelloFront.Helpers;
using FiorelloFront.Models;
using FiorelloFront.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FiorelloFront.Services
{
    public class SliderInfoService : ISliderInfoService
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public SliderInfoService(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task CreateAsync(IFormFile signImage,string title,string description)
        {
            string fileName = Guid.NewGuid() + "_" + signImage.FileName;
            await signImage.SaveFileAsync(fileName, _env.WebRootPath, "img");

            SliderInfo sliderInfo = new()
            {
                Title = title,
                Description = description,
                SignImage = signImage.ToString(),
            };

            await _context.AddAsync(sliderInfo);
            await _context.SaveChangesAsync();
            
        }

        public async Task<List<SliderInfo>> GetAllDataAsync()
        {
            return await _context.SliderInfos.Where(m => !m.SoftDelete).ToListAsync();
        }
    }
}
