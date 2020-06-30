using ParaglidingProject.SL.Core.Pilot.NS.TransfertObjects;
using System.Linq;

namespace ParaglidingProject.SL.Core.Pilot.NS.MapperProfiles
{
    public static class PilotMapping
    {
        public static PilotDto MapPilotDto(this Models.Pilot pilot)
        {            
            // BLACK BOX
            var pilotDto = new PilotDto
            {
                PilotId = pilot.ID,
                FirstName = pilot.FirstName,
                LastName = pilot.LastName,
                Address = pilot.Address,
                PhoneNumber = pilot.PhoneNumber,
                Weight = pilot.Weight,
                Role = pilot.Role,
                IsActive = pilot.IsActive,
                NumberOfFlights = pilot.Flights.Count,
                Flights = pilot.Flights,
                Possessions = pilot.Possessions,
                TraineeshipPayments = pilot.TraineeshipPayments,
                PilotTraineeships = pilot.PilotTraineeships
            };

            return pilotDto;
        }
    }
}
