using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.Appointy.Data;
using MVC.Appointy.Models;
using System.Net;
using System.Net.Mail;

namespace MVC.Appointy.Controllers;

[Route("doctor")]
public class DoctorController : Controller
{
    private readonly AppointyDbContext _db;

    public DoctorController(AppointyDbContext db)
    {
        _db = db;
    }
    
    [HttpGet("login")]
    public IActionResult Login()
    {
        return View();
    }

    // POST: /Doctor/Login
    [HttpPost]
    public IActionResult Login(Doctor doctor)
    {
        var doctorInDb = _db.Doctors.FirstOrDefault(d => d.Email == doctor.Email && d.Password == doctor.Password);
        if (doctorInDb == null)
        {
            ModelState.AddModelError("LoginFailed", "Login failed. Please check your credentials.");
            return View(doctor);
        }
        return RedirectToAction("DoctorPanel");
    }
    
    // GET: /Doctor/DoctorPanel
    [HttpPost("doctorpanel")]
    public IActionResult DoctorPanel()
    {
        return View();
    }

    [HttpPost]
    public IActionResult GetAppointments(DateTime date, int doctorId)
    {
        var appointments = _db.Appointments
            .Where(a => a.AppointmentDate.Date == date.Date && a.DoctorId == doctorId)
            .Include(a => a.Patient)
            .ToList();

        return View("DoctorPanel", appointments);
    }

    public List<Doctor> GetDoctorList()
    {
        return _db.Doctors.ToList();
    }
    
    [HttpGet]
    public IActionResult ForgotPassword()
    {
        return View();
    }

    [HttpPost]
    public IActionResult ForgotPassword(string email)
    {
        var doctor = _db.Doctors.FirstOrDefault(d => d.Email == email);
        if (doctor == null)
        {
            ModelState.AddModelError("EmailNotFound", "Bu e-posta adresi veritabanında bulunamadı.");
            return View();
        }

        try
        {
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("your_email@gmail.com", "your_password"),
                EnableSsl = true,
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress("your_email@gmail.com"),
                Subject = "Şifre Sıfırlama",
                Body = "Şifrenizi sıfırlamak için lütfen şu bağlantıyı tıklayın: [link]",
                IsBodyHtml = true,
            };

            mailMessage.To.Add(email);
            smtpClient.Send(mailMessage);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "E-posta gönderme işlemi sırasında bir hata oluştu.");
        }

        return Ok();
    }
}