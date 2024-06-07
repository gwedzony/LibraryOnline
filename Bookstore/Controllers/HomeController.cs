using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Bookstore.Models;
using Database.Context;

namespace Bookstore.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly DatabaseContext _context;

    public HomeController(ILogger<HomeController> logger, DatabaseContext context)
    {
        _context = context;
        _logger = logger;
    }

    public IActionResult Index()
    {
        /*ViewBag.NewestBooks = (from nb in _context.BookPreviewNewests
            join b in _context.Books
                on nb.BookId equals b.BookId
            select new NewestBooksCards
            {
                Id = nb.NewestBookId,
                BookUrl = nb.BookLink,
                BookImage = nb.SmallCoverImg,
                BookTitle = b.Title,
                BookAuthor = $"{b.Author.Name} {b.Author.Surname}",
                BookDescription = b.Description,
                AddDateTime = b.AddDateTime
            }).ToList();*/
      
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}