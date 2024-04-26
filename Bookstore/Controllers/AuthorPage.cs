using Microsoft.AspNetCore.Mvc;

namespace Bookstore.Controllers;

public class AuthorPage : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}