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
        if (password != passwordCheck) 
        {
            ViewData["chyba"] = "Hesla se neshodují.";
            return View();
        }
       
        
        _db.Users.Add(new User()
        {
            Username = username,
            Password = password
        });
        _db.SaveChanges();

        return Redirect("/User/Login");
        
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(string username, string password)
    {
        if (string.IsNullOrEmpty(username) ||
            string.IsNullOrEmpty(password))
        {
            ViewData["chyba"] = "Jméno nebo heslo není zadáno.";

            return View();
        }

        User? loggedUser = _db
            .Users
            .Where(u => u.Username == username)
            .FirstOrDefault();

        if (loggedUser == null)
        {
            ViewData["chyba"] = "Uživatel nenalezen.";
            return View();
        }

        if (loggedUser.Password != password)
        {
            ViewData["chyba"] = "Neplatné heslo.";
            return View();
        }

        return Redirect("/User/Profile");
    }

    public IActionResult Profile()
    {
        return View();
    }


}