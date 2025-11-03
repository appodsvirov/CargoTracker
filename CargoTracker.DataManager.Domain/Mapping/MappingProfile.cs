using AutoMapper;
using CargoTracker.DataManager.Domain.Entities;
using CargoTracker.DataManager.Domain.Models;
using CargoTracker.Dtos;

namespace CargoTracker.DataManager.Domain.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Entity -> Domain
        CreateMap<CargoEntity, Cargo>();
        CreateMap<TrackEntity, Track>();

        // Domain -> DTO
        CreateMap<Cargo, CargoDto>();
        CreateMap<Track, TrackDto>();

        // DTO -> Domain
        CreateMap<CargoDto, Cargo>();
        CreateMap<TrackDto, Track>();

        // Domain -> Entity
        CreateMap<Cargo, CargoEntity>();
        CreateMap<Track, TrackEntity>();
    }
}
