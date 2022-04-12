using AutoMapper;
using Events.Api.Database.Models;
using Events.Api.Models;

namespace Events.Api.Mappers;

public class AddressMappingProfile : Profile
{
    public AddressMappingProfile()
    {
        CreateMap<Address, AddressModel>().ReverseMap();
    }
}
    