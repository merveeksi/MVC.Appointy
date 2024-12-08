using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.Appointy.Data;
using MVC.Appointy.Models;

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
        // List<Doctor> objDoctorList = _db.Doctors.ToList();
        // foreach (var doctor in objDoctorList)
        //     doctor.Freetime = GetAvailableDates(doctor.Id); // Müsait günleri al
        //
        // return View(objDoctorList);
        return View();
    }

    [HttpPost]
    public IActionResult GetAppointments(DateTime date, int doctorId)
    {
        var appointments = _db.Appointments
            .Where(a => a.AppointmentDate.Date == date.Date && a.DoctorId == doctorId)
            .Include(a => a.Patient) // Hasta bilgilerini dahil et
            .ToList();

        return View("DoctorPanel", appointments); // Randevuları DoctorPanel.cshtml'e gönder
    }
}