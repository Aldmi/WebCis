namespace Domain.Entities
{
    public class RailwayStStationStations
    {
        public int RailStId { get; set; }
        public RailwayStationDto RailwayStationDto { get; set; }

        public int StatId { get; set; }
        public StationDto StationDto { get; set; }
    }
}