using Microsoft.AspNetCore.Mvc;

namespace _06_AspNetCore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
