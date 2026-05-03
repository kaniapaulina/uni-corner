namespace BookApp.Models.DbModels
{
    public class Library
    {
        public int LibraryId { get; set; }
        public string Name { get; set; }
        public virtual List<Book> Books { get; set; } = new List<Book>();
        public Library() { }
    }
}