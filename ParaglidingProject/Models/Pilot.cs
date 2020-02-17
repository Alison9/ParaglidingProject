using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParaglidingProject.Models
{
    public class Pilot
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Adress { get; set; }

        public string PhoneNumber { get; set; }

        public int Weight { get; set; }
        public int? PostitionID { get; set; }

        public Position? Position { get; set; }
        public bool IsActif { get; set; }
        public ICollection<Flight> Flights { get; set; }
        public ICollection<Payment> Payments { get; set; }
        public ICollection<Participation> Participations { get; set; }
        public ICollection<Teaching> Teachings { get; set; }
        public ICollection<Obtaining> Obtainings { get; set; }
    }
}
