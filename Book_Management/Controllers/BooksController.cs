//using Book_Management.Models;
//using Book_Management.Services;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace Book_Management.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class BooksController : ControllerBase
//    {
//        private readonly BookService _bookService;

//        public BooksController(BookService bookService)
//        {
//            _bookService = bookService;
//        }

//        [HttpGet("GetAllBooks")]
//        public ActionResult<List<Book>> GetAllBooks()
//        {
//            List<Book> books = _bookService.GetBooks();
//            if (books == null || books.Count == 0)
//            {
//                return NotFound("No books found");
//            }
//            else
//            {
//                return Ok(books);
//            }
//        }

//        [HttpGet("GetSingleBook")]
//        public ActionResult<Book> GetBook(int id)
//        {
//            Book book = _bookService.GetBookById(id);
//            if (book == null)
//            {
//                return NotFound("Book Not found");
//            }
//            else
//            {
//                return Ok(book);
//            }
//        }

//        [HttpPost]
//        public ActionResult AddBook(Book book)
//        {
//            _bookService.AddBook(book);
//            return Ok("Book added successfully");
//        }

//        [HttpPut]
//        public ActionResult UpdateBook(Book bookToBeUpdated)
//        {
//            int bookUpdateStatus = _bookService.UpdateBook(bookToBeUpdated);
//            if (bookUpdateStatus == -1)
//            {
//                return NotFound("Book Not FOund");
//            }
//            else if (bookUpdateStatus == 1)
//            {
//                return Ok("Book updated successfully");
//            }
//            else
//            {
//                return BadRequest("Bad request");
//            }
//        }

//        [HttpDelete]
//        public ActionResult DeleteBook(int id)
//        {
//            int deleteStatus = _bookService.DeleteBook(id);
//            if (deleteStatus == -1)
//            {
//                return NotFound("Book Not found");
//            }
//            else if (deleteStatus == 1)
//            {
//                return Ok("Book Deleted Successfully");
//            }
//            else
//            {
//                return BadRequest("Bad request");
//            }
//        }
//    }
//}
