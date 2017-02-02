namespace Domain.Entities
{
    public class RegShStationsListOfStops
    {
        public int RegShId { get; set; }
        public RegulatorySchedule RegulatorySchedule { get; set; }

        public int StatId { get; set; }    
        public Station Station { get; set; }
    }
}