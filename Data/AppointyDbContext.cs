using Microsoft.EntityFrameworkCore;
using MVC.Appointy.Models;

namespace MVC.Appointy.Data;

public class AppointyDbContext : DbContext
{
    public AppointyDbContext(DbContextOptions<AppointyDbContext> options) : base(options)
    {
    }

    public DbSet<Patient> Patients { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Appointment> Appointments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
    }
}