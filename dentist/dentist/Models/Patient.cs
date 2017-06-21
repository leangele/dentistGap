using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace dentist.Models
{
    public class Patient : IPatient
    {

        private readonly ApplicationDbContext _context;

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Identification { get; set; }
        public int Age { get; set; }
        public string ContactNumber { get; set; }
        public string ContactName { get; set; }
        public DateTime LastAppointment { get; set; }
        public DateTime NextAppointment { get; set; }
        public ICollection<Treatment> Treatments { get; set; }

        public Patient(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Patient> GetPatients()
        {
            return _context.Patients;
        }
    }
}