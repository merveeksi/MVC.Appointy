using Microsoft.AspNetCore.Mvc;
using MVC.Appointy.Data;

namespace MVC.Appointy.Controllers
{
    public class FooterController : Controller
    {
        private readonly AppointyDbContext _db;

        public FooterController(AppointyDbContext db)
        {
            _db = db;
        }
        
        [HttpGet("footer/hakkimizda")]
        public IActionResult Hakkimizda()
        {
            return View();
        }

        [HttpGet("footer/blog")]
        public IActionResult Blog()
        {
            return View();
        }

        [HttpGet("footer/gizlilikpolitikasi")]
        public IActionResult GizlilikPolitikasi()
        {
            return View("GizlilikPolitikasi");
        }

        [HttpGet("footer/ziyaretsaatleri")]
        public IActionResult ZiyaretSaatleri()
        {
            return View("ZiyaretSaatleri");
        }

        [HttpGet("footer/kvkk")]
        public IActionResult KVKK()
        {
            return View("KVKK");
        }
    }
} 