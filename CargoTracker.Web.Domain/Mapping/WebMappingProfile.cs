using AutoMapper;
using CargoTracker.Dtos;
using CargoTracker.Web.Domain.Models;

namespace CargoTracker.Web.Domain.Mapping;

public class WebMappingProfile : Profile
{
    public WebMappingProfile()
    {
        // Dto -> Model and back
        CreateMap<CargoDto, Cargo>().ReverseMap();
        CreateMap<TrackDto, Track>().ReverseMap();
    }
}
