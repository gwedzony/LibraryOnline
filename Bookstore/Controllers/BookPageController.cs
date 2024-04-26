using Microsoft.AspNetCore.Mvc;

namespace Bookstore.Controllers;

public class BookPageController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}