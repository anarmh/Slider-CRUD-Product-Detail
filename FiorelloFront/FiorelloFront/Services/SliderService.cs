using FiorelloFront.Areas.Admin.ViewModels.Slider;
using FiorelloFront.Data;
using FiorelloFront.Models;
using FiorelloFront.Helpers;
using FiorelloFront.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using FiorelloFront.ViewModels;

namespace FiorelloFront.Services
{
    public class SliderService : ISliderService
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public SliderService(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<int> GetCountAsync()
        {
           return await _context.Sliders.Where(m=>m.Status).CountAsync();
        }

        public async Task CreateAsync(List<IFormFile> images)
        {

            foreach (var item in images)
            {
                string fileName = Guid.NewGuid().ToString() + "_" + item.FileName;

                await item.SaveFileAsync(fileName, _env.WebRootPath, "img");

                Slider slider = new()
                {
                    Image = fileName
                };
                await _context.AddAsync(slider);

            }

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            Slider slider = await getByIdAsync(id);

            _context.Sliders.Remove(slider);

            await _context.SaveChangesAsync();

            string path = Path.Combine(_env.WebRootPath, "img", slider.Image);

            if (File.Exists(path))
            {
               File.Delete(path);
            }
           
        }

        public async  Task EditAsync(Slider slider, IFormFile newImage)
        {
            string oldPath = Path.Combine(_env.WebRootPath, "img", slider.Image);

            if (File.Exists(oldPath))
            {
               File.Delete(oldPath);
            }

            string fileName = Guid.NewGuid().ToString() + "_" + newImage.FileName;

            await newImage.SaveFileAsync(fileName, _env.WebRootPath, "img");

            slider.Image = fileName;

            await _context.SaveChangesAsync();
        }

        public async Task<List<Slider>> GetAllAsync()=> await _context.Sliders.Where(m => !m.SoftDelete).ToListAsync();

        public async Task<List<Slider>> GetAllByStatusAsync()
        {
            return await _context.Sliders.Where(m => m.Status).ToListAsync();
        }

        public async Task<List<Areas.Admin.ViewModels.Slider.SliderVM>> GetAllMappedDatasAsync()
        {
            List<Areas.Admin.ViewModels.Slider.SliderVM> sliderList = new();
            List<Slider> sliders = await _context.Sliders.Where(m => !m.SoftDelete).ToListAsync();

            foreach (var slider in sliders)
            {
                Areas.Admin.ViewModels.Slider.SliderVM model = new()
                {
                    Id = slider.Id,
                    Image = slider.Image,
                    Status = slider.Status,
                };
                sliderList.Add(model);
            }

            return sliderList;
        }

        public async Task<Slider> getByIdAsync(int id)
        {
           return await _context.Sliders.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<bool> ChangeStatusAsync(Slider slider)
        {

            if (slider.Status && await GetCountAsync() != 1)
            {
                slider.Status = false;

            }
            else
            {
                slider.Status = true;
            }
            await _context.SaveChangesAsync();
            return slider.Status;
        }
    }
}
