using FiorelloFront.Data;
using Microsoft.AspNetCore.Mvc;

namespace FiorelloFront.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        

        public IActionResult Index()
        {

            return View();
        }
    }
}
