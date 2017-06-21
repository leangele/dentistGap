using dentist.Models;

namespace dentist
{
    public interface IUnitOfWork
    {
        IPatient Patient { get; set; }
        ITreatment Treatment { get; set; }
    }
}