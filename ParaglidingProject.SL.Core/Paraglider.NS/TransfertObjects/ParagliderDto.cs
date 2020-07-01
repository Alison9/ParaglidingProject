using System;
using System.ComponentModel.DataAnnotations;

namespace ParaglidingProject.SL.Core.Paraglider.NS.TransfertObjects
{
    public class ParagliderDto
    {
        public int ParagliderId { get; set; }
        public string Name { get; set; }
        [DataType(DataType.Date)]
        public DateTime CommissioningDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime LastRevision { get; set; }
        public int ParagliderModelId { get; set; }
        public int NumerOfFlights { get; set; }
    }
}
