using Database.Context;
using Database.Data.BookScheme;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Controllers;

public class AuthorPage : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly DatabaseContext _context;

    public AuthorPage(ILogger<HomeController> logger, DatabaseContext context)
    {
        _context = context;
        _logger = logger;
    }
    // GET
    public async Task<IActionResult> Index()
    {
        var author = _context.Authors.Include(b => b.Books)
            .ThenInclude(g => g.Genre)
            .Include(a => a.Books)
            .ThenInclude(bt=>bt.BookType)
            .FirstOrDefaultAsync(a => a.AuthorId == 7);
        
        ViewBag.AuthorsBooks = author.Result.Books.ToList();
        return View(await author);
    }
}