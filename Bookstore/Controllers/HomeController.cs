using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Bookstore.Models;
using Database.Context;
using Microsoft.EntityFrameworkCore;

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
       ViewBag.NewestBooks = (from nb in _context.BookNewsCards
            join b in _context.Books
                on nb.BookId equals b.BookId
            select new NewestBooksCards
            {
                Id = nb.BookNewsCardId,
                BookUrl = nb.BookLink,
                BookImage = nb.SmallCoverImg,
                BookTitle = b.Title,
                BookAuthor = $"{b.Author.Name} {b.Author.Surname}",
                BookDescription = b.Description,
                AddDateTime = nb.WhenCreated
            }).ToList();
       
       ViewBag.BookCollections = _context.Collections.ToList();
       
       Random random = new Random();
       
       var randomCollectionNumber =  random.Next(1 ,_context.Collections.ToList().Count+1);
     
      var collection = _context.Collections
           .Include(c => c.BookCollections)
           .ThenInclude(bc => bc.Book)
           .ThenInclude(b=>b.Author)
           .FirstOrDefaultAsync(c => c.CollectionId == randomCollectionNumber);
        
       var booksInCollection = collection.Result.BookCollections.Select(bc => bc.Book).ToList();

       ViewBag.BookPage = _context.BookPages.ToList();
       ViewBag.BooksInCollection = booksInCollection;
       ViewBag.CollectionName = collection.Result.CollectionName;
       
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