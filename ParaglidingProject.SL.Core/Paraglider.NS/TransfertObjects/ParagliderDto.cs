using System;

namespace ParaglidingProject.SL.Core.Paraglider.NS.TransfertObjects
{
    public class ParagliderDto
    {
        public int ParagliderId { get; set; }
        public string Name { get; set; }
        public DateTime CommissioningDate { get; set; }
        public DateTime LastRevision { get; set; }
        public string ParagliderModelAprrovalNumber { get; set; }
        public int NumerOfFlights { get; set; }
    }
}
