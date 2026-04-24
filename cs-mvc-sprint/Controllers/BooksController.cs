using System.Reflection.Metadata.Ecma335;
using cs_mvc_sprint.Model.Services;
using cs_mvc_sprint.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace cs_mvc_sprint.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBooksService _booksService;

        public BooksController(IBooksService booksService)
        {
            _booksService = booksService;
        }

        [HttpGet]
        public IActionResult GetAllBooks()
        {
            return Ok(_booksService.GetAllBooks());
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetBookById(int id)
        {
            return Ok(_booksService.GetBookById(id));
        }

        [HttpGet]
        [Route("authors/{id}")]
        public IActionResult GetBooksByAuthorId(int id)
        {
            return Ok(_booksService.GetBooksByAuthorId(id));
        }

        [HttpPost]
        public IActionResult AddBook(Book book)
        {
            try
            {
                _booksService.AddBook(book);
                return Ok(book);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeteleBook(int id)
        {
            if (_booksService.DeleteBook(id))
            {
                return NoContent();
            }
            return NotFound();
        }
    }
}
