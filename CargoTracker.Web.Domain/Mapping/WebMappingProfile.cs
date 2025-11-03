using AutoMapper;
using CargoTracker.Dtos;
using CargoTracker.Web.Domain.Models;

namespace CargoTracker.Web.Domain.Mapping;

public class WebMappingProfile : Profile
{
    public WebMappingProfile()
    {
        // Dto -> Model and back
        CreateMap<CargoDto, Cargo>(MemberList.None).ReverseMap();
        CreateMap<TrackDto, Track>(MemberList.None).ReverseMap();
    }
}
