using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dentist.Models
{
    public class TreatmentDto
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Price { get; set; }
        public string Detail { get; set; }
    }
}