using ASPNETCore.Data;
using ASPNETCore.Models;
using Microsoft.AspNetCore.Mvc;




namespace ASPNETCore.Controllers;

public class UserController : Controller
{
    private readonly ApplicationDbContext _db;

    public UserController(ApplicationDbContext db)
    {
        _db = db;
    }
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
            _db.Users.Add(new User()
            {
                Username = username,
                Password = password
            });
            _db.SaveChanges();

            return Redirect("/User/Login");
        }
    }
    public IActionResult Profile()
    {
        return View();
    }
}