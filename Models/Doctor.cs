using System.ComponentModel.DataAnnotations;

namespace MVC.Appointy.Models;

public class Doctor
{
    [Key]
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Gender { get; set; }
    public string Tc { get; set; }
    public string Specialty { get; set; }
    public string Password { get; set; }
        
    public string FullName
    {
        get { return FirstName + " " + LastName; }
    }
    
}