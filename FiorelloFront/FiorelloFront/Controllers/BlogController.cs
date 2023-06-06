using FiorelloFront.Data;
using FiorelloFront.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FiorelloFront.Controllers
{
    public class BlogController : Controller
    {
        private readonly AppDbContext _context;

        public BlogController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(int? id)
        {
            if (id is null) return BadRequest();

            Blog blog= await _context.Blogs.Where(m=>!m.SoftDelete).FirstOrDefaultAsync(x=>x.Id==id);

            if (blog == null) return NotFound();

            return View(blog);
        }
    }
}
