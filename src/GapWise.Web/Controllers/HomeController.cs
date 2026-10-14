using Microsoft.AspNetCore.Mvc;

namespace GapWise.Web.Controllers;

public sealed class HomeController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
}
