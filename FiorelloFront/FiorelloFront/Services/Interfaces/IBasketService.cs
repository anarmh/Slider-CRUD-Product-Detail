using FiorelloFront.Models;
using FiorelloFront.ViewModels;

namespace FiorelloFront.Services.Interfaces
{
    public interface IBasketService
    {
       public List<BasketVM> GetAll();
        public void AddProduct(List<BasketVM> basket, Product product);
        void DeleteProduct(int? id);
        int GetCount();
    }
}
