using AutoMapper;
using Events.Api.Database.Models;
using Events.Api.Models;

namespace Events.Api.Mappers;

public class EventProfile : Profile
{
    public EventProfile()
    {
        CreateMap<Event, EventModel>()
            .ForMember(dest => 
                dest.Type, 
                opt => opt.MapFrom(src => src.TypeId))
            .ForMember(dest => 
                    dest.Status, 
                opt => opt.MapFrom(src => src.StatusId))
            .ReverseMap();
    }
}