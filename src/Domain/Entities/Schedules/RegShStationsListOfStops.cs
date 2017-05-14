

namespace Domain.Entities
{
    public class RegShStationsListOfStops
    {
        public int RegShId { get; set; }
        public RegulatoryScheduleDto RegulatoryScheduleDto { get; set; }

        public int StatId { get; set; }    
        public StationDto StationDto { get; set; }
    }
}