using BookApp.Models.DbModels;
using Microsoft.EntityFrameworkCore;
namespace BookApp.Models
{
    public class DatabaseContext : DbContext
    {
        // Konstruktor przyjmujący parametry konfiguracyjne z pliku Program.cs
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Library> Libraries { get; set; }
    }
}