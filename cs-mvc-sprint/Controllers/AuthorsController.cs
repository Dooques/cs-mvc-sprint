using System.Diagnostics;
using cs_mvc_sprint.Models;
using Microsoft.AspNetCore.Mvc;
using cs_mvc_sprint.Utils;
using cs_mvc_sprint.Model.Services;
using Microsoft.AspNetCore.Http.HttpResults;

namespace cs_mvc_sprint.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorsService _authorsService;

        public AuthorsController(IAuthorsService authorsService)
        {
            _authorsService = authorsService;
        }

        [HttpGet]
        public IActionResult GetAllAuthors()
        {
            return Ok(_authorsService.GetAllAuthors());
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetAuthorById(int id)
        {
            return Ok(_authorsService.GetAuthorById(id));
        }

        [HttpPost]
        public IActionResult AddAuthor(Author author)
        {
            if (_authorsService.AddAuthor(author))
            {
                return Ok(author);
            }
            else return BadRequest();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteAuthor(int id)
        {
            if (_authorsService.DeleteAuthor(id))
            {
                return NoContent();
            }
            else return NotFound();
        }
    }
}
