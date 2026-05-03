using Microsoft.AspNetCore.Mvc;
using BookApp.Models;
using BookApp.Models.DbModels;

namespace BookApp.Controllers
{
    public class BooksController : Controller
    {
        private readonly DatabaseContext _context;
        // Wstrzykiwanie zależności (Dependency Injection)
        public BooksController(DatabaseContext context)
        {
            _context = context;
        }

        // ZADANIE

        [HttpGet]
        public IActionResult Create()
        {
            return View(new Book());
        }

        [HttpPost]
        [ValidateAntiForgeryToken] // Dodajemy dla bezpieczeństwa przed atakami CSRF
        public IActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                _context.Books.Add(book);
                _context.SaveChanges();
                return RedirectToAction(nameof(ViewAll));
            }
            return View(book);
        }

        [HttpGet]
        public IActionResult ViewAll()
        {
            var books = _context.Books.ToList(); // Pobranie wszystkich autorów z bazy
            return View(books);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var book = _context.Books.FirstOrDefault(x => x.BookId == id);
            if (book == null) return NotFound();
            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Book book)
        {
            if (!ModelState.IsValid)
                return View(book);
            _context.Books.Update(book); // Zastępuje stare .Entry(author).State = EntityState.Modified
            _context.SaveChanges();

            return RedirectToAction(nameof(ViewAll));
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();
            var book = _context.Books.FirstOrDefault(x => x.BookId == id);
            if (book == null) return NotFound();
            return View(book);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirm(int id)
        {
            var book = _context.Books.FirstOrDefault(x => x.BookId == id);
            if (book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(ViewAll));
        }
    }
}
