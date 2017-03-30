using AutoMapper;
using Domain.Entities;
using WebCis.Model;

namespace WebCis.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Station, StationModel>();
            CreateMap<StationModel, Station>();

            CreateMap<RailwayStation, RailwayStationModel>();
            CreateMap<RailwayStationModel, RailwayStation>();
        }
    }
}