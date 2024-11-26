using MVC.Appointy.Data;
using MVC.Appointy.Models;
using System.Collections.Generic;
using System.Linq;

namespace MVC.Appointy.Services;

public class AppointmentService(AppointyDbContext db) : IAppointmentService
{
    public List<Appointment> GetAllAppointments()
    { 
        return db.Appointments.ToList();
    }

    public void CreateAppointment(Appointment appointment)
    {
        db.Appointments.Add(appointment);
        db.SaveChanges();
    }
}
