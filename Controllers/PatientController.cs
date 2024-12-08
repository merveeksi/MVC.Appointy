using Microsoft.AspNetCore.Mvc;
using MVC.Appointy.Data;
using MVC.Appointy.Models;
using System.Linq;

namespace MVC.Appointy.Controllers;

[Route("patient")]
public class PatientController : Controller
{
    private readonly AppointyDbContext _db;
    public PatientController(AppointyDbContext db)
    {
        _db = db;
    }
    
    [HttpGet("patientpanel")]
    // GET: /Patient/PatientPanel
    public IActionResult PatientPanel()
    {
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

    // GET: /Patient/Register
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
    
    [HttpGet("login")]
    // GET: /Patient/Login
    public IActionResult Login()
    {
        return View();
    }
    
    // POST: /Patient/Login
    [HttpPost]
    public IActionResult Login(Patient patient)
    {
        var patientInDb = _db.Patients.FirstOrDefault(p => p.Tc == patient.Tc && p.Password == patient.Password);
        if (patientInDb == null)
        {
            ModelState.AddModelError("LoginFailed", "Giriş başarısız. Lütfen kimlik bilgilerinizi kontrol edin.");
            return View(patient);
        }
        return RedirectToAction("PatientPanel", "Patient");
    }
}