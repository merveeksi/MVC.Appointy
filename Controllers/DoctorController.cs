using Microsoft.AspNetCore.Mvc;
using MVC.Appointy.Data;
using MVC.Appointy.Models;

namespace MVC.Appointy.Controllers;

public class DoctorController : Controller
{
    private readonly AppointyDbContext _db;
    public DoctorController(AppointyDbContext db)
    {
        _db = db;
    }
    
    // GET
    public IActionResult Index()
    {
        List<Doctor> objDoctorList = _db.Doctors.ToList();
        return View();
    }
}