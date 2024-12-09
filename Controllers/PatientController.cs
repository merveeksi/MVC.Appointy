using Microsoft.AspNetCore.Mvc;
using MVC.Appointy.Data;
using MVC.Appointy.Models;
using System.Linq;
using System;

namespace MVC.Appointy.Controllers;

[Route("patient")]
public class PatientController : Controller
{
    private readonly AppointyDbContext _db;

    public PatientController(AppointyDbContext db)
    {
        _db = db;
    }
    
    [HttpGet("login")]
    // GET: /Patient/Login
    public IActionResult Login()
    {
        return View();
    }
    
    // POST: /Patient/Login
    [HttpPost("login")]
    public IActionResult Login(Patient patient)
    {
        var patientInDb = _db.Patients.FirstOrDefault(p => p.Email == patient.Email && p.Password == patient.Password);
        if (patientInDb == null)
        {
            ModelState.AddModelError("LoginFailed", "Giriş başarısız. Lütfen email ve şifrenizi kontrol edin.");
            return View(patient);
        }
        return RedirectToAction("PatientPanel");
    }
    
    [HttpGet("register")]
    public IActionResult Register()
    {
        return View();
    }
    
    // POST: /Patient/Register
    [HttpPost]
    public IActionResult Register(Patient patient)
    {
        if (ModelState.IsValid)
        {
            _db.Patients.Add(patient);
            _db.SaveChanges();
            return RedirectToAction("PatientPanel");
        }
        return View(patient);
    }
    
    [HttpGet("patientpanel")]
    // GET: /Patient/PatientPanel
    public IActionResult PatientPanel()
    {
        ViewBag.DoctorList = _db.Doctors.ToList();

        var firstPatient = _db.Patients.FirstOrDefault();
        if (firstPatient == null)
        {
            return NotFound();
        }

        var model = new Patient
        {
            Appointments = _db.Appointments.Where(a => a.PatientId == firstPatient.Id).ToList(),
            NewAppointment = new Appointment()
        };
        return View(model);
    }

    // POST: /Patient/PatientPanel
    [HttpPost]
    public IActionResult PatientPanel(Patient patient)
    {
        if (ModelState.IsValid)
        {
            patient.NewAppointment.PatientId = _db.Patients.First().Id;
            _db.Appointments.Add(patient.NewAppointment);
            _db.SaveChanges();
            return RedirectToAction("PatientPanel");
        }
        return View(patient);
    }
    
    // [HttpGet("logout")]
    // // GET: /Patient/Logout
    // public IActionResult Logout()
    // {
    //     return RedirectToAction("Login");
    // }
    //
    // [HttpGet("delete/{id}")]
    // // GET: /Patient/Delete/5
    // public IActionResult Delete(int id)
    // {
    //     var patient = _db.Patients.Find(id);
    //     if (patient == null)
    //     {
    //         return NotFound();
    //     }
    //     _db.Patients.Remove(patient);
    //     _db.SaveChanges();
    //     return RedirectToAction("Login");
    // }
    
    [HttpGet("forgotpassword")]
    public IActionResult ForgotPassword()
    {
        return View();
    }

    [HttpPost("forgotpassword")]
    public IActionResult ForgotPassword(string email)
    {
        var patient = _db.Patients.FirstOrDefault(p => p.Email == email);
        if (patient == null)
        {
            ModelState.AddModelError("EmailNotFound", "Bu e-posta adresi ile kayıtlı hasta bulunamadı.");
            return View();
        }

        // Güvenlik için rastgele bir şifre oluştur
        string newPassword = GenerateRandomPassword();
        patient.Password = newPassword;
        _db.SaveChanges();

        // TODO: E-posta gönderme işlemi burada yapılacak
        // Gerçek uygulamada e-posta servisi entegre edilmeli

        TempData["SuccessMessage"] = "Yeni şifreniz e-posta adresinize gönderildi.";
        return RedirectToAction("Login");
    }

    private string GenerateRandomPassword()
    {
        const string chars = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*";
        var random = new Random();
        return new string(Enumerable.Repeat(chars, 10)
            .Select(s => s[random.Next(s.Length)]).ToArray());
    }
    
}