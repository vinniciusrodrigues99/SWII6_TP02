using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TP01_WII6.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TP01_WII6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly AppDbContext _context;
        public BooksController(AppDbContext context)
        {
            _context = context;
        }
        // GET: api/<BooksController>
        [HttpGet("Name")]
        public ActionResult<string> GetBookName()
        {
            var book = _context.Books.Include(b => b.Authors).FirstOrDefault();
            return book?.GetName();
        }

        [HttpGet("ToString")]
        public ActionResult<string> GetBookToString()
        {
            var book = _context.Books.Include(b => b.Authors).FirstOrDefault();
            return book?.ToString() ?? string.Empty;
        }

        [HttpGet("AuthorNames")]
        public ActionResult<string> GetAuthorNames()
        {
            var book = _context.Books.Include(b => b.Authors).FirstOrDefault();
            return book?.GetAuthorNames();
        }

        [HttpGet("ApresentarLivro")]
        public IActionResult ApresentarLivro()
        {
            var book = _context.Books.Include(b => b.Authors).FirstOrDefault();
            //var author = _context.Authors.Include(b => b.Name).FirstOrDefault();
            if (book == null) return NotFound();

            //var htmlContent = $"<h1>{book.Name}</h1><ul>{string.Join("", book.Authors.Select(a => $"<li>{a.Name}</li>"))}</ul>";
            var htmlContent = $"<h1>{book.Name}</h1><ul>{string.Join("", book.Authors.Select(a => $"<li>{a.Name}</li>"))}</ul>";

            return Content(htmlContent, "text/html");
        }
    }
}
