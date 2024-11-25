using Microsoft.AspNetCore.Mvc;
using MVC.Appointy.Data;
using MVC.Appointy.Models;
using System.Linq;

namespace MVC.Appointy.Controllers;

public class PatientController : Controller
{
    private readonly AppointyDbContext _db;
    public PatientController(AppointyDbContext db)
    {
        _db = db;
    }
    
    // GET
    public IActionResult Index()
    {
        List<Patient> objPatientList = _db.Patients.ToList();
        var model = new Patient
        {
            Appointments = _db.Appointments.Where(a => a.PatientId == objPatientList.FirstOrDefault().Id).ToList()
        };
        return View(model);
    }
    
}