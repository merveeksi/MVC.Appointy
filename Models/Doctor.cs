using System.ComponentModel.DataAnnotations;

namespace MVC.Appointy.Models;

public class Doctor
{
    public Doctor(int id, string firstName, string lastName, string gender, string tc, string specialty, string password, List<DateTime> freetime, ICollection<Appointment> appointments):this()
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Gender = gender;
        Tc = tc;
        Specialty = specialty;
        Password = password;
        Freetime = freetime;
        Appointments = appointments;
    }

    public Doctor()
    {
        
    }

    [Key]
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Gender { get; set; }
    public string Tc { get; set; }
    public string Specialty { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
        
    public string FullName
    {
        get { return FirstName + " " + LastName; }
    }

    public List<DateTime> Freetime { get; set; } //Doktor çalışma saatleri
    public ICollection<Appointment> Appointments { get; set; }
}