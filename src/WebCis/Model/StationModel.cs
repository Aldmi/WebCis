using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.Entities;

namespace WebCis.Model
{
    public class StationModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Введите Ecp код станции")]
        public int EcpCode { get; set; }

        [Required(ErrorMessage = "Введите название станции")]
        public string Name { get; set; }

        public string Description { get; set; }


       // public virtual ICollection<RegulatorySchedule> RegulatoryScheduleDispatchStations { get; set; }        //Один ко многим RegulatorySchedule.DispatchStations

        //public virtual ICollection<RegulatorySchedule> RegulatoryScheduleDestinationStations { get; set; }     //Один ко многим RegulatorySchedule.DestinationStations


        //public virtual List<RegShStationsListOfStops> RegulatorySchedulesListOfStops { get; set; }             //Многие ко многим с RegulatorySchedule.ListOfStops

        //public virtual List<RegShStationsListWithOutStops> RegulatorySchedulesListWithoutStops { get; set; }   //Многие ко многим с RegulatorySchedule.ListWithoutStops 


        //public virtual ICollection<OperativeSchedule> OperativeSchedulesListOfStops { get; set; }            //Многие ко многим с OperativeSchedule.ListOfStops

        //public virtual ICollection<OperativeSchedule> OperativeSchedulesListWithoutStops { get; set; }       //Многие ко многим с OperativeSchedule.ListWithoutStops 




       // public virtual ICollection<RailwayStationModel> RailwayStations { get; set; }                      //Многие ко многим с RailwayStation (для вывода всех станций по вокзалу) 
    }
}