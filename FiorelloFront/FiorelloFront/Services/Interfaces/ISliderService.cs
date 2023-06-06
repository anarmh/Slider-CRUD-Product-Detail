using FiorelloFront.Areas.Admin.ViewModels.Slider;
using FiorelloFront.Models;
using Microsoft.AspNetCore.Http;

namespace FiorelloFront.Services.Interfaces
{
    public interface ISliderService
    {
        public Task<List<Slider>> GetAllAsync();
        public Task<Slider> getByIdAsync(int id);
        public Task<List<SliderVM>> GetAllMappedDatasAsync();
        public Task CreateAsync(List<IFormFile> images);
        public Task DeleteAsync(int id);
        public Task EditAsync(Slider slider,IFormFile newImage);
        public Task<List<Slider>> GetAllByStatusAsync();
        public Task<int> GetCountAsync();
        public Task<bool> ChangeStatusAsync(Slider slider);
    }
}
