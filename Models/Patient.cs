using System.ComponentModel.DataAnnotations;

namespace MVC.Appointy.Models;

public class Patient
{
    public Patient(int id, string firstName, string lastName, string gender, string tc, DateTime birthDate, string password, ICollection<Appointment> appointments, Appointment newAppointment) : this()
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Gender = gender;
        Tc = tc;
        BirthDate = birthDate;
        Password = password;
        Appointments = appointments;
        NewAppointment = newAppointment;
    }

    public Patient()
    {
        
    }

    [Key]
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Gender { get; set; }
    public string Tc { get; set; }
    public DateTime BirthDate { get; set; }
    public string Password { get; set; }
    
    public string FullName
    {
        get { return FirstName + " " + LastName; }
    }
    
    public ICollection<Appointment> Appointments { get; set; }
    public Appointment NewAppointment { get; set; }
    
    
}
