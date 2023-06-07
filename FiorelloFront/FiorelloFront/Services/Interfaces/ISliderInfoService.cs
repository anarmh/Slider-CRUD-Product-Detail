using FiorelloFront.Models;

namespace FiorelloFront.Services.Interfaces
{
    public interface ISliderInfoService
    {
        public Task<List<SliderInfo>> GetAllDataAsync();
        public Task CreateAsync(IFormFile signImage,string title,string description);
    }
}
