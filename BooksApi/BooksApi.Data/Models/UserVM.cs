using BooksApi.Models;

namespace BooksApi.Data.Models
{
    public class UserVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public List<Book> Book { get; set; }
    }
}
