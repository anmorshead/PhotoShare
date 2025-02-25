using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhotoShare.Data;
using PhotoShare.Models;
using Microsoft.AspNetCore.Authorization;

namespace PhotoShare.Controllers
{
    public class HomeController : Controller
    {
        private readonly PhotoShareContext _context;

        // Constructor
        public HomeController(PhotoShareContext context)
        {
            _context = context;
        }

        // Home page - ../ or ../Home/Index
        public async Task<IActionResult> Index()
        {
            // get the photos from db where visibility is true
            var photos = await _context.Photo.Where(m => m.IsVisible == true).ToListAsync();

            return View(photos);
        }

        // Display a photo by id - ../Home/PhotoDetails/328
        public async Task<IActionResult> PhotoDetails(int id)
        {
            // get photo from db by id
            var photo = await _context.Photo
                .Include(m => m.ApplicationUser)
                .Include(p => p.Tags)
                .FirstOrDefaultAsync(m => m.PhotoId == id);

            return View(photo);
        }

        // Privacy page - ../Home/Privacy/
        public IActionResult Privacy()
        {
            return View();
        }
    }
}