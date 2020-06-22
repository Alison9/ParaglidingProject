using AutoMapper;
using ParaglidingProject.SL.Core.Pilot.NS.TransfertObjects;

namespace ParaglidingProject.SL.Core.Pilot.NS.MapperProfiles
{
    public class PilotAutoMapping : Profile
    {
        public PilotAutoMapping()
        {
            CreateMap<Models.Pilot, PilotDto>()
                
                //.ForMember(target => target.Name, options => options
                //    .MapFrom(source => source.FirstName + source.LastName))
                
                //.ForMember(target => target.PilotId, options => options
                //    .MapFrom(source => source.ID))
                
                .ForMember(target => target.NumberOfFlights, options => options
                    .MapFrom(source => source.Flights.Count));
        }
    }
}
