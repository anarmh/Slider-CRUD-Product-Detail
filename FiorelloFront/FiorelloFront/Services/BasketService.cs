using FiorelloFront.Data;
using FiorelloFront.Models;
using FiorelloFront.Services.Interfaces;
using FiorelloFront.ViewModels;
using Newtonsoft.Json;

namespace FiorelloFront.Services
{
    public class BasketService : IBasketService
    {
   
        private readonly IHttpContextAccessor _accessor;
        public BasketService( IHttpContextAccessor accessor)
        {
            
            _accessor = accessor;
        }

        public void AddProduct(List<BasketVM> basket, Product product)
        {
            BasketVM existProduct = basket.FirstOrDefault(m => m.Id == product.Id);

            if (existProduct == null)
            {
                basket.Add(new BasketVM
                {
                    Id = product.Id,
                    Count = 1
                });
            }
            else
            {
                existProduct.Count++;
            }


            _accessor.HttpContext.Response.Cookies.Append("basket", JsonConvert.SerializeObject(basket));
        }

        public void DeleteProduct(int? id)
        {
            List<BasketVM> basketDatas = JsonConvert.DeserializeObject<List<BasketVM>>(_accessor.HttpContext.Request.Cookies["basket"]);

            var data = basketDatas.FirstOrDefault(m => m.Id == id);

            basketDatas.Remove(data);

            _accessor.HttpContext.Response.Cookies.Append("basket", JsonConvert.SerializeObject(basketDatas));
        }

        public List<BasketVM> GetAll()
        {
            List<BasketVM> basket;
            if (_accessor.HttpContext.Request.Cookies["basket"] != null)
            {
                basket = JsonConvert.DeserializeObject<List<BasketVM>>(_accessor.HttpContext.Request.Cookies["basket"]);
            }
            else
            {
                basket = new List<BasketVM>();
            }
            return basket;
        }

        public int GetCount()
        {
            List<BasketVM> basket;
            if (_accessor.HttpContext.Request.Cookies["basket"] != null)
            {
                basket = JsonConvert.DeserializeObject<List<BasketVM>>(_accessor.HttpContext.Request.Cookies["basket"]);
            }
            else
            {
                basket = new List<BasketVM>();
            }
            return basket.Sum(m => m.Count);
        }
    }
}
