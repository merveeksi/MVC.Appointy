using Microsoft.AspNetCore.Mvc;
using MVC.Appointy.Models;
using MVC.Appointy.Services; // Assuming you have a service namespace

namespace MVC.Appointy.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IAppointmentService _appointmentService; // Use a service interface

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService; // Inject the service
        }

        // GET
        public IActionResult Index()
        {
            // Fetch appointments using the service
            var appointments = _appointmentService.GetAllAppointments(); // Example method
            return View(appointments); // Pass appointments to the view
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}