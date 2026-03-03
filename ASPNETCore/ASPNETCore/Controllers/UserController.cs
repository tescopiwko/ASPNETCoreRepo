using Microsoft.AspNetCore.Mvc;

namespace ASPNETCore.Controllers;

public class UserController : Controller
{
    // GET
    public IActionResult Index()
    {
        return RedirectToAction("Index", "Home");
    }

    public IActionResult Login()
    {
        return View();
    }

    public IActionResult Register()
    {
        return View();
    }

    public IActionResult Profile()
    {
        return View();
    }
}