using Microsoft.AspNetCore.Mvc;

namespace Intranet.Controllers;

public class HomeBookController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}