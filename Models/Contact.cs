using System.ComponentModel.DataAnnotations;

namespace MVC.Appointy.Models;

public class Contact
{
    public Contact()
    {
    }

    public Contact(int id, string firstName, string lastName, string email, string messageWrite)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        MessageWrite = messageWrite;
    }

    [Key]
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string? MessageWrite { get; set; }

    public string FullName
    {
        get { return FirstName + " " + LastName; }
    }
}
