using System;
using System.Collections.Generic;

namespace dentist.Models
{
    public interface ITreatment
    {
        string Detail { get; set; }
        DateTime EndDate { get; set; }
        int Id { get; set; }
        decimal Price { get; set; }
        DateTime StartDate { get; set; }

        IEnumerable<Treatment> GetTreatments();
        Treatment GetTreatment(int id);
    }
}