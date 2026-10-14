using Microsoft.AspNetCore.Mvc;

namespace GapWise.Web.Controllers;

public sealed class TeacherController : Controller
{
    [HttpGet]
    public IActionResult Index() => View();
}
