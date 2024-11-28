using System.ComponentModel.DataAnnotations;

namespace MVC.Appointy.Models;

public class Doctor
{
    public Doctor(int id, string firstName, string lastName, Gender gender, string tc, string specialty, string email, string password, List<DateTime> freetime, ICollection<Appointment> appointments):this()
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Gender = gender;
        Tc = tc;
        Specialty = specialty;
        Email = email;
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
    public Gender Gender { get; set; }

    [Required]
    [RegularExpression(@"^\d{11}$", ErrorMessage = "T.C. Kimlik Numarası 11 haneli ve sadece rakamlardan oluşmalıdır.")]
    public string Tc { get; set; }
    public string Specialty { get; set; }
    public string Email { get; set; }

    [Required(ErrorMessage = "Şifre gereklidir.")]
    [StringLength(100, MinimumLength = 6, ErrorMessage = "Şifre en az 6 karakter olmalıdır.")]
    public string Password { get; set; }
        
    public string FullName
    {
        get { return FirstName + " " + LastName; }
    }

    public List<DateTime>? Freetime { get; set; } //Doktor çalışma saatleri
    public ICollection<Appointment> Appointments { get; set; }
    public ICollection<Contact> Contacts{ get; set; }
}