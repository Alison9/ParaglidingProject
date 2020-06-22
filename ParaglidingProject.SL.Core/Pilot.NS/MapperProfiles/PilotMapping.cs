using ParaglidingProject.SL.Core.Pilot.NS.TransfertObjects;

namespace ParaglidingProject.SL.Core.Pilot.NS.MapperProfiles
{
    public static class PilotMapping
    {
        public static PilotDto MapPilotDto(this Models.Pilot pilot)
        {
            var pilotDto = new PilotDto
            {
                Address = pilot.Address,
                NumberOfFlights = pilot.Flights.Count
            };

            return pilotDto;
        }
    }
}
