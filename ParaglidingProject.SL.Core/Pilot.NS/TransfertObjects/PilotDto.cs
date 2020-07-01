using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.Collections;
using System.Collections.Generic;

namespace ParaglidingProject.SL.Core.Pilot.NS.TransfertObjects
{
    public class PilotDto
    {
        public int PilotId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public int Weight { get; set; }
        #nullable enable
        public Models.Role? Role { get; set; }
        #nullable disable
        public bool IsActive { get; set; }
        public int NumberOfFlights { get; set; }
        public decimal TotalFlightHours { get; set; }
        public ICollection<Models.Flight> Flights { get; set; }
        public ICollection<Models.Possession> Possessions { get; set; }
        public ICollection<Models.TraineeshipPayment> TraineeshipPayments { get; set; }
        public ICollection<Models.PilotTraineeship> PilotTraineeships { get; set; }

    }
}
