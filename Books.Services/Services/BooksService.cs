namespace Books.Services.Services
{
    public class BooksService(BooksRepository booksRepository)
    {
        private readonly BooksRepository booksRepository = booksRepository;

        public List<Book> GetBooks()
        {
            return booksRepository.GetBooks();
        }

        public Book GetBookById(int id)
        {
            return booksRepository.GetBookById(id);
        }

        public void AddBook(Book book)
        {
            booksRepository.AddBook(book);
        }

        public int UpdateBook(Book book)
        {
            return booksRepository.UpdateBook(book);
        }

        public int DeleteBook(int id)
        {
            return booksRepository.DeleteBook(id);
        }

        public List<Book> GetFilteredBooks(string genre)
        {
            return booksRepository.GetFilteredBooks(genre);
        }
    }
}
