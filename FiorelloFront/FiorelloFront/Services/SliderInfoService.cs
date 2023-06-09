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
                SignImage = fileName
            };

            await _context.AddAsync(sliderInfo);
            await _context.SaveChangesAsync();
            
        }

        public async  Task DeleteAsync(int id)
        {
           SliderInfo sliderInfo= await GetByIdAsync(id);
            _context.SliderInfos.Remove(sliderInfo);
            await _context.SaveChangesAsync();
            string path = Path.Combine(_env.WebRootPath, "img", sliderInfo.SignImage);

            if (File.Exists(path))
            {
                File.Delete(path);
            }

        }

        public async Task EditAsync(SliderInfo sliderInfo, IFormFile newSignImage, string newTitle, string newDescription)
        {
           string oldSliderInfoPath=Path.Combine(_env.WebRootPath,"img",sliderInfo.SignImage);

            if(File.Exists(oldSliderInfoPath))
            {
                File.Delete(oldSliderInfoPath);
            }


            string fileName = Guid.NewGuid().ToString() + "_" + newSignImage.FileName;

            await newSignImage.SaveFileAsync(fileName, _env.WebRootPath, "img");

            sliderInfo.SignImage = fileName;
            sliderInfo.Title=newTitle;
            sliderInfo.Description=newDescription;

            await _context.SaveChangesAsync();
        }

        public async Task<List<SliderInfo>> GetAllDataAsync()
        {
            return await _context.SliderInfos.Where(m => !m.SoftDelete).ToListAsync();
        }

        public  async Task<SliderInfo> GetByIdAsync(int id)
        {
            return await _context.SliderInfos.FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}
