using Microsoft.AspNetCore.Mvc;

namespace PictureShare_.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Manage()
        {
            return View();
        }
    }
}
