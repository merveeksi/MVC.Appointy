// Create a new file: MVC.Appointy/Services/IAppointmentService.cs

using Microsoft.AspNetCore.Http.HttpResults;
using MVC.Appointy.Models;

public interface IAppointmentService
{
    List<Appointment> GetAllAppointments(); // Define methods as needed
}
