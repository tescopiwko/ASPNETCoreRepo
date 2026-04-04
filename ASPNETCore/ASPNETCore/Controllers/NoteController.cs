using ASPNETCore.Data;
using ASPNETCore.Models;
using Microsoft.AspNetCore.Mvc;


namespace ASPNETCore.Controllers
{
    public class NoteController : Controller
    {

        private readonly ApplicationDbContext _db;

        public NoteController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpPost]
        public IActionResult Add(string title, string content)
        {
            if (string.IsNullOrEmpty(title) ||
                string.IsNullOrEmpty(content))
            {
                TempData["chyba"] = "Titulek i text musi byt zadan";
                TempData["text"] = content;

                return RedirectToAction("Profile", "User");
            }

            User loggedUser = _db
                .Users
                .Where(u => u.Username ==
                HttpContext.Session.GetString("logged"))
                .First();

            Note novaPoznamka = new Note()
            {
                Title = title,
                Content = content,
                Owner = loggedUser
            };

            _db.Notes.Add(novaPoznamka);
            _db.SaveChanges();

            return RedirectToAction("Profile", "User");
        }

        public IActionResult List()
        {
            string? loggedUsername = HttpContext.Session.GetString("logged");

            if (loggedUsername == null)
            {
                return Redirect("/User/Login");
            }

            User loggedUser = _db
                .Users
                .Where(u => u.Username == loggedUsername)
                .First();

            List<Note> poznamkyPrihlasenehoUzivatele = _db
                .Notes
                .Where(n => n.Owner == loggedUser)
                .ToList();

            poznamkyPrihlasenehoUzivatele.Reverse();

            return View(poznamkyPrihlasenehoUzivatele);
        }
    }
}
