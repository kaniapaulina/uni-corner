namespace BookApp.Models.DbModels
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        // Relacja 1:N z klasą Book
        public virtual List<Book> Books { get; set; } = new List<Book>();
        public Author() { }
    }
}