using AutoMapper;
using Domain.Entities;
using Domain.Entities.RailwayStations;

using WebCis.Model;
using WebCis.ViewModel;

namespace WebCis.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<StationDto, StationViewModel>();
            CreateMap<StationViewModel, StationDto>();

            CreateMap<RailwayStationDto, RailwayStationViewModel>();
            CreateMap<RailwayStationViewModel, RailwayStationDto>();
        }
    }
}