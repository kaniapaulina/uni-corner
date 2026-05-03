namespace BookApp.Models.DbModels
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public BookType BookType { get; set; }
        // Klucze obce i właściwości nawigacyjne dla relacji
        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }
        public int LibraryId { get; set; }
        public virtual Library Library { get; set; }

        public Book() { }
        public Book(int bookId, string title, BookType bookType)
        {
            BookId = bookId;
            Title = title;
            BookType = bookType;
        }
    }
    public enum BookType { Fantasy, Other }
}