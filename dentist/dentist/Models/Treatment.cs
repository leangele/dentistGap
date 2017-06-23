using System;
using System.Collections.Generic;
using System.Linq;

namespace dentist.Models
{
    public class Treatment : ITreatment
    {
        private readonly ApplicationDbContext _context;
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Price { get; set; }
        public string Detail { get; set; }

        public Treatment(ApplicationDbContext context)
        {
            _context = context;
        }

        public Treatment()
        {
            
        }

        public IEnumerable<Treatment> GetTreatments()
        {
            return _context.Treatments;
        }
        public Treatment GetTreatment(int id)
        {
            return _context.Treatments.FirstOrDefault(x => x.Id == id);
        }
    }
}