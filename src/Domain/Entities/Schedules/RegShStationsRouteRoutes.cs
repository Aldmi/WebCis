namespace Domain.Entities
{
    public class RegShStationsRouteRoutes
    {
        public int RegShId { get; set; }
        public RegulatoryScheduleDto RegulatoryScheduleDto { get; set; }

        public int StatRouteId { get; set; }
        public StationsRouteDto StationRouteDto { get; set; }
    }
}