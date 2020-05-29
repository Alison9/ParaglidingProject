using ParaglidingProject.SL.Core.TransfertObjects;

namespace ParaglidingProject.SL.Core.Pilot.NS.MapperProfiles
{
    public static class PilotMapping
    {
        public static PilotDto MapPilotDto(this Models.Pilot pilot)
        {
            var pilotDto = new PilotDto
            {
                PilotId = pilot.ID,
                Name = $"{pilot.FirstName} {pilot.LastName}",
                Address = pilot.Address,
                NumberOfFlights = pilot.Flights.Count
            };

            return pilotDto;
        }
    }
}
