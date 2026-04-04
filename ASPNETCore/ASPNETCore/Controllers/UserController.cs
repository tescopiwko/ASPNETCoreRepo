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
            Password = BCrypt.Net.BCrypt.HashPassword(password)
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

        if (!BCrypt.Net.BCrypt.Verify(password, loggedUser.Password))
        {
            ViewData["chyba"] = "Neplatné heslo.";
            return View();
        }

        HttpContext.Session.SetString("logged", username);
        

        return Redirect("/User/Profile");
    }

    public IActionResult Profile()
    {
        string? logged = HttpContext.Session.GetString("logged");

        if (logged == null)
        {
            return Redirect("/User/Login");
        }

        User loggedUser = _db
            .Users
            .Where(u => u.Username == logged)
            .First();

        return View(loggedUser);
    }

    public new IActionResult SignOut()
    {
        HttpContext.Session.Clear();
        Response.Cookies.Delete("AspNetCore.Session");

        TempData["logged"] = "";

        return Redirect("/Home/Index");
    }

}