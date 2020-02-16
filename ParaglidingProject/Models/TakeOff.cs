using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParaglidingProject.Models
{
    public class TakeOff
    {
        public int ID { get; set; }

        public int IDFlight { get; set; }

        public int IDSite { get; set; }

        public Flight flight { get; set; }

        public ICollection<Site> Sites { get; set; }
    }
}