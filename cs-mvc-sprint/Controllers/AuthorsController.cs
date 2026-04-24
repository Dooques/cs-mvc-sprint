using System.Diagnostics;
using cs_mvc_sprint.Models;
using Microsoft.AspNetCore.Mvc;
using cs_mvc_sprint.Utils;
using cs_mvc_sprint.Model.Services;

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

        public IActionResult GetAllAuthors()
        {
            return Ok(_authorsService.GetAllAuthors());
        }
    }
}
