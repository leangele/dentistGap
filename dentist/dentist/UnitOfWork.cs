using dentist.Models;

namespace dentist
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IPatient Patient { get; set; }
        public ITreatment Treatment { get; set; }



        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Patient = new Patient(_context);
            Treatment = new Treatment(_context);

        }
    }
}