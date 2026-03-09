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

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Register(string username, string password, string passwordCheck)
    {
        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            ViewData["chyba"] = "Jméno nebo heslo není zadáno.";
            return View();
        }
        else if (password != passwordCheck) 
        {
            ViewData["chyba"] = "Hesla se neshodují.";
            return View();
        }
        else
        {
            return Redirect("/User/Login");
        }
    }
    public IActionResult Profile()
    {
        return View();
    }
}