using Microsoft.AspNetCore.Mvc;
using MVC.Appointy.Models;

namespace MVC.Appointy.Controllers;

[Route("contact")]
public class ContactController : Controller
{
    // GET
    [HttpGet("contact")]
    public IActionResult Contact()
    {
        return View(new Contact());
    }
    
    [HttpPost("contact")]
    public IActionResult Contact(Contact contact)
    {
        if (ModelState.IsValid)
        {
            // Burada veritabanına ekleme işlemini yapın
            // Örneğin: _context.Contacts.Add(contact);
            // _context.SaveChanges();

            // Başarılı bir şekilde kaydedildiğinde bir mesaj gösterebilirsiniz
            ViewBag.Message = "Mesajınız başarıyla gönderildi!";
            return View(new Contact());
        }

        return View(contact);
    }
}