using Microsoft.AspNetCore.Mvc;

namespace _06_AspNetCore.Controllers
{
    public class HomeController : Controller
    {
        // Otevírá Views/Home/Index.cshtml
        public IActionResult Index()
        {
            return View();
        }

        // Otevírá Views/Home/Onas.cshtml
        public IActionResult Onas()
        {
            return View();
        }

        // Otevírá Views/Home/Sluzby.cshtml
        public IActionResult Sluzby()
        {
            return View();
        }

        // Otevírá Views/Home/Kontakt.cshtml
        public IActionResult Kontakt()
        {
            return View();
        }
    }
}