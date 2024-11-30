using Microsoft.AspNetCore.Mvc;

namespace MVC.Appointy.Controllers;

[Route("deneme")]
public class DenemeController : Controller
{
    // GET
    [HttpGet("deneme")]
    public IActionResult Deneme()
    {
        return View();
    }
    
    // POST
    [HttpPost]
    public IActionResult Deneme(string name)
    {
        return View();
    }
}