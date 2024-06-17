using Database.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Controllers;

public class BookPageController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly DatabaseContext _context;

    public BookPageController(ILogger<HomeController> logger, DatabaseContext context)
    {
        _context = context;
        _logger = logger;
    }

    // GET
    public async Task <IActionResult> Index(int id)
    {
        var bookPage = _context.BookPages
            .Include(b=>b.Book)
            .Include(b=>b.Book.Author)
            .Include(b=>b.Book.Genre)
            .Include(b=>b.Book.BookType)
            .FirstOrDefaultAsync(x => x.BookId == id);
        
        if (bookPage == null)
        {
            return NotFound();
        }
        
        return View(await bookPage);
    }
    
}