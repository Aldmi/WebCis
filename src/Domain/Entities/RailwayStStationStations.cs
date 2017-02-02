namespace Domain.Entities
{
    public class RailwayStStationStations
    {
        public int RailStId { get; set; }
        public RailwayStation RailwayStation { get; set; }

        public int StatId { get; set; }
        public Station Station { get; set; }
    }
}