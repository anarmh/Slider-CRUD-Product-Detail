using FiorelloFront.Data;
using FiorelloFront.Models;
using FiorelloFront.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FiorelloFront.Controllers
{
    public class ContactController : Controller
    {
        private readonly AppDbContext _context;

        public ContactController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            List<FlowersExpert> flowersExperts = await _context.FlowersExperts.Where(m => !m.SoftDelete).ToListAsync();
            ContactVM model = new()
            {
                FlowersExperts = flowersExperts
            };
            return View(model);
        }
    }
}
