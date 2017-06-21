using System;
using System.Collections.Generic;

namespace dentist.Models
{
    public interface IPatient
    {
        int Age { get; set; }
        string ContactName { get; set; }
        string ContactNumber { get; set; }
        int Id { get; set; }
        string Identification { get; set; }
        DateTime LastAppointment { get; set; }
        string Name { get; set; }
        DateTime NextAppointment { get; set; }
        ICollection<Treatment> Treatments { get; set; }
    }
}