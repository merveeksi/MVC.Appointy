using System.Net;
using System.Net.Mail;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.Appointy.Data;
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
            using (var context = new AppointyDbContext(new DbContextOptions<AppointyDbContext>()))
            {
                context.Contacts.Add(contact);
                context.SaveChanges();
            }

            // Send email to the hospital email address
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("your_hospital_email@gmail.com", "your_email_password"),
                EnableSsl = true,
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress("your_hospital_email@gmail.com"),
                Subject = "Yeni İletişim Mesajı",
                Body = $"Ad: {contact.FirstName} {contact.LastName}\nEmail: {contact.Email}\nMesaj: {contact.MessageWrite}",
                IsBodyHtml = false,
            };

            mailMessage.To.Add("your_hospital_email@gmail.com");

            try
            {
                smtpClient.Send(mailMessage);
            }
            catch (Exception ex)
            {
                // Handle email sending error (optional)
                ViewBag.Message = "Mesajınız gönderilirken bir hata oluştu.";
                return View(contact);
            }

            ViewBag.Message = "Mesajınız başarıyla gönderildi!";
            return RedirectToAction("Contact"); // Redirect to avoid resubmission
        }

        return View(contact);
    }
}