using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MVC.Appointy.Models.Enums;

namespace MVC.Appointy.Models;

public class Appointment
{
    [Key] 
    public int Id { get; set; }
    public DateTime AppointmentDate { get; set; }

    public DateTime AppointmentTime { get; set; }
    public Clinic SelectedClinic { get; set; }
    public string SelectedDoctor { get; set; }
    
    public string? Notes { get; set; }

    public int DoctorId { get; set; }

    [ForeignKey("DoctorId")]
    public Doctor Doctor { get; set; }

    public int PatientId { get; set; }

    [ForeignKey("PatientId")]
    public Patient Patient { get; set; }

    public Appointment()
    {
        
    }
    
    public Appointment(int id, DateTime appointmentTime ,DateTime appointmentDate, Clinic selectedClinic, string selectedDoctor, string notes, int doctorId, Doctor doctor, int patientId, Patient patient) : this()
    {
        Id = id;
        AppointmentTime = appointmentTime;
        AppointmentDate = appointmentDate;
        SelectedClinic = selectedClinic;
        SelectedDoctor = selectedDoctor;
        Notes = notes;
        DoctorId = doctorId;
        Doctor = doctor;
        PatientId = patientId;
        Patient = patient;
    }
}