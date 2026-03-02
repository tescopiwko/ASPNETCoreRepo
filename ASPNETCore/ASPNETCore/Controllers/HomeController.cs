using Microsoft.AspNetCore.Mvc;

namespace ASPNETCore.Controllers
{
    public class HomeController : Controller
    {
        // Otev�r� Views/Home/Index.cshtml
        public IActionResult Index()
        {
            return View();
        }

        // Otev�r� Views/Home/Onas.cshtml
        public IActionResult Onas()
        {
            return View();
        }

        // Otev�r� Views/Home/Sluzby.cshtml
        public IActionResult Sluzby()
        {
            return View();
        }

        // Otev�r� Views/Home/Kontakt.cshtml
        public IActionResult Kontakt()
        {
            return View();
        }
    }
}