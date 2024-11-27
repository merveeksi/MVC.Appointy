using Microsoft.AspNetCore.Mvc;
using MVC.Appointy.Models;
using MVC.Appointy.Services; // Assuming you have a service namespace

namespace MVC.Appointy.Controllers
{
    [Route("appointment")]
    public class AppointmentController : Controller
    {
        private readonly IAppointmentService _appointmentService; // Use a service interface

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService; // Inject the service
        }

        [HttpGet("Index")]
        // GET
        public IActionResult Index()
        {
            // Fetch appointments using the service
            var appointments = _appointmentService.GetAllAppointments(); // Example method
            return View(appointments); // Pass appointments to the view
        }

        [HttpGet("create")]
        public IActionResult Create()
        {
            return View(new Appointment());
        }

        [HttpPost("create")]
        public IActionResult Create(Appointment appointment, string AppointmentHour, string AppointmentMinute)
        {
            if (ModelState.IsValid)
            {
                // Saat ve dakikayı birleştir
                var appointmentDateTime = new DateTime(
                    appointment.AppointmentDate.Year,
                    appointment.AppointmentDate.Month,
                    appointment.AppointmentDate.Day,
                    int.Parse(AppointmentHour),
                    int.Parse(AppointmentMinute),
                    0
                );

                // Tarih kontrolü
                if (appointmentDateTime < DateTime.Now)
                {
                    ModelState.AddModelError("AppointmentDate", "Randevu tarihi geçmişte olamaz.");
                    return View(appointment);
                }

                // 12:00 - 13:00 arası kontrolü
                if (appointmentDateTime.Hour == 12)
                {
                    ModelState.AddModelError("AppointmentTime", "Randevu saati 12:00 ile 13:00 arasında olamaz.");
                    return View(appointment);
                }

                appointment.AppointmentDate = appointmentDateTime;

                _appointmentService.CreateAppointment(appointment);
                return RedirectToAction("Index");
            }
            return View(appointment);
        }
    }
}