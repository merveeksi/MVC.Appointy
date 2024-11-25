using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC.Appointy.Models;

public class Appointment
{
    [Key] 
    public int Id { get; set; }
    public static DateTime AppointmentDate { get; set; }
    public static string SelectedClinic { get; set; }
    public static string SelectedDoctor { get; set; }
    
    public string Notes { get; set; }

    public int DoctorId { get; set; }

    [ForeignKey("DoctorId")]
    public Doctor Doctor { get; set; }

    public int PatientId { get; set; }

    [ForeignKey("PatientId")]
    public static Patient Patient { get; set; }

    public ICollection<Patient> Patients { get; set; }

    
}