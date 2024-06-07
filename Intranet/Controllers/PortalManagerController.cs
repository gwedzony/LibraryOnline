using Microsoft.AspNetCore.Mvc;

namespace Intranet.Controllers;

public class PortalManagerController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}