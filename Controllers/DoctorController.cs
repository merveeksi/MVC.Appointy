using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
//
//     // Müsait günleri döndüren metod
//     private List<DateTime> GetAvailableDates(int doctorId)
//     {
//         // Burada doktorun randevu almadığı günleri kontrol edin
//         var appointments = _db.Appointments
//             .Where(a => a.DoctorId == doctorId)
//             .Select(a => a.AppointmentDate)
//             .ToList();
//
//         // Örnek olarak, 1 hafta boyunca her gün için müsait günleri döndür
//         List<DateTime> availableDates = new List<DateTime>();
//         DateTime startDate = DateTime.Today;
//         for (int i = 0; i < 7; i++)
//         {
//             DateTime date = startDate.AddDays(i);
//             if (!appointments.Contains(date))
//             {
//                 availableDates.Add(date);
//             }
//         }
//         return availableDates;
//     }
// }
}