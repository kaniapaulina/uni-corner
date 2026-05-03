using Microsoft.AspNetCore.Mvc;
using BookApp.Models;
using BookApp.Models.DbModels;

namespace BookApp.Controllers
{
    public class AuthorController : Controller
    {
        private readonly DatabaseContext _context;
        // Wstrzykiwanie zależności (Dependency Injection)
        public AuthorController(DatabaseContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        // ZADANIE

        [HttpGet]
        public IActionResult Create()
        {
            return View(new Author());
        }

        [HttpPost]
        [ValidateAntiForgeryToken] // Dodajemy dla bezpieczeństwa przed atakami CSRF
        public IActionResult Create(Author author)
        {
            if (ModelState.IsValid)
            {
                _context.Authors.Add(author);
                _context.SaveChanges();
                return RedirectToAction(nameof(ViewAll));
            }
            return View(author);
        }

        [HttpGet]
        public IActionResult ViewAll()
        {
            var authors = _context.Authors.ToList(); // Pobranie wszystkich autorów z bazy
            return View(authors);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var author = _context.Authors.FirstOrDefault(x => x.AuthorId == id);
            if (author == null) return NotFound();
            return View(author);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Author author)
        {
            if (!ModelState.IsValid)
                return View(author);
            _context.Authors.Update(author); // Zastępuje stare .Entry(author).State = EntityState.Modified
            _context.SaveChanges();

            return RedirectToAction(nameof(ViewAll));
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();
            var author = _context.Authors.FirstOrDefault(x => x.AuthorId == id);
            if (author == null) return NotFound();
            return View(author);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirm(int id)
        {
            var author = _context.Authors.FirstOrDefault(x => x.AuthorId == id);
            if (author != null)
            {
                _context.Authors.Remove(author);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(ViewAll));
        }
    }
}
