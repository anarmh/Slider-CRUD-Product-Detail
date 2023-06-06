using FiorelloFront.Areas.Admin.ViewModels.Category;
using FiorelloFront.Data;
using FiorelloFront.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FiorelloFront.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ArchiveController : Controller
    {

        private readonly AppDbContext _context;

        public ArchiveController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Categories()
        {
            List<CategoryVM> list = new();
            List<Category> categories = await _context.Categories.Where(m => m.SoftDelete).ToListAsync();

            foreach (var category in categories)
            {
                CategoryVM model = new()
                {
                    Id = category.Id,
                    Name = category.Name
                };
                list.Add(model);
            }

            return View(list);
            
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ExtractCategory(int id)
        {
            var existCategory = await _context.Categories.Where(m => m.SoftDelete).FirstOrDefaultAsync(m => m.Id == id);


            existCategory.SoftDelete = false;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Categories));
        }
    }
}
