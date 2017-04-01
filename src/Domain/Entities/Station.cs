using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    /// <summary>
    /// ЖД Станция.
    /// </summary>
    public class Station : IEntitie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int EcpCode { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }


        public virtual ICollection<RegulatorySchedule> RegulatoryScheduleDispatchStations { get; set; }        //Один ко многим RegulatorySchedule.DispatchStations

        public virtual ICollection<RegulatorySchedule> RegulatoryScheduleDestinationStations { get; set; }     //Один ко многим RegulatorySchedule.DestinationStations


        public virtual List<RegShStationsListOfStops> RegulatorySchedulesListOfStops { get; set; }             //Многие ко многим с RegulatorySchedule.ListOfStops

        public virtual List<RegShStationsListWithOutStops> RegulatorySchedulesListWithoutStops { get; set; }   //Многие ко многим с RegulatorySchedule.ListWithoutStops 


        //public virtual ICollection<OperativeSchedule> OperativeSchedulesListOfStops { get; set; }            //Многие ко многим с OperativeSchedule.ListOfStops

        //public virtual ICollection<OperativeSchedule> OperativeSchedulesListWithoutStops { get; set; }       //Многие ко многим с OperativeSchedule.ListWithoutStops 




        public virtual ICollection<RailwayStStationStations> RailwayStations { get; set; }                      //Многие ко многим с RailwayStation (для вывода всех станций по вокзалу) 
    }

}
