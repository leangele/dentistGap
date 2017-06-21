using System.Data.Entity;

namespace dentist.Models
{
    public interface IApplicationDbContext
    {
        DbSet<Patient> Patients { get; set; }
        DbSet<Treatment> Treatments { get; set; }
    }
}