using System.ComponentModel.DataAnnotations;

namespace MVC.Appointy.Models;

public enum Gender
{
    Erkek,
    Kadın
}

public class Patient
{
    public Patient(int id, string firstName, string lastName, Gender gender, string tc, DateTime birthDate, string email, string password) : this()
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Gender = gender;
        Tc = tc;
        BirthDate = birthDate;
        Email = email;
        Password = password;
    }

    public Patient()
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

    public DateTime BirthDate { get; set; }

    [Required(ErrorMessage = "E-posta gereklidir.")]
    [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi girin.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Şifre gereklidir.")]
    [StringLength(100, MinimumLength = 6, ErrorMessage = "Şifre en az 6 karakter olmalıdır.")]
    public string Password { get; set; }
    
    public string FullName
    {
        get { return FirstName + " " + LastName; }
    }
    
    public List<Appointment> Appointments { get; set; } = new List<Appointment>();
    public ICollection<Contact> Contacts { get; set; }
    public Appointment NewAppointment { get; set; }
}
