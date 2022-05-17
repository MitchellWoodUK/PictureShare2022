using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PictureShare_.Data;
using PictureShare_.Models;
using System.Diagnostics;

namespace PictureShare_.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;

            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var pictures = await _db.Pictures.Where(p => p.Public).Include("Category").ToListAsync();

            foreach (var picture in pictures)
            {
                picture.Comments = await _db.Comments.Where(x => x.PictureId == picture.Id).Include("User").ToListAsync();
            }


            return View(pictures);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}