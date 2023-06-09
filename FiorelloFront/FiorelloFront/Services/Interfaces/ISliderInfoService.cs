using FiorelloFront.Models;

namespace FiorelloFront.Services.Interfaces
{
    public interface ISliderInfoService
    {
        public Task<List<SliderInfo>> GetAllDataAsync();
        public Task<SliderInfo> GetByIdAsync(int id);
        public Task CreateAsync(IFormFile signImage,string title,string description);
        public Task DeleteAsync(int id);
        public Task EditAsync(SliderInfo sliderInfo, IFormFile newSignImage,string newTitle,string newDescription);
    }
}
