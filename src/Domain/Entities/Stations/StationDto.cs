using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities.RailwayStations;


namespace Domain.Entities
{
    /// <summary>
    /// ЖД Станция.
    /// </summary>
    public class StationDto : IEntitie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int EcpCode { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }


        public virtual ICollection<RegulatoryScheduleDto> RegulatoryScheduleDispatchStations { get; set; }
        //Один ко многим RegulatoryScheduleDto.DispatchStations

        public virtual ICollection<RegulatoryScheduleDto> RegulatoryScheduleDestinationStations { get; set; }
        //Один ко многим RegulatoryScheduleDto.DestinationStations


        public virtual List<RegShStationsListOfStops> RegulatorySchedulesListOfStops { get; set; }
        //Многие ко многим с RegulatoryScheduleDto.ListOfStops

        public virtual List<RegShStationsListWithOutStops> RegulatorySchedulesListWithoutStops { get; set; }
        //Многие ко многим с RegulatoryScheduleDto.ListWithoutStops 


        //public virtual ICollection<OperativeScheduleDto> OperativeSchedulesListOfStops { get; set; }            //Многие ко многим с OperativeScheduleDto.ListOfStops

        //public virtual ICollection<OperativeScheduleDto> OperativeSchedulesListWithoutStops { get; set; }       //Многие ко многим с OperativeScheduleDto.ListWithoutStops 




        public virtual ICollection<RailwayStStationStations> RailwayStations { get; set; }                        //Многие ко многим с RailwayStationDto (для вывода всех станций по вокзалу) 
    

        public virtual ICollection<StationsRouteDto> StationsRouteDto { get; set; }                               //Один ко многим с StationsRouteDto

    }
}
