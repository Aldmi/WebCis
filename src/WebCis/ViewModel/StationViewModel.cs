using System.ComponentModel.DataAnnotations;

namespace WebCis.ViewModel
{
    public class StationViewModel
    {
        public int Id { get; set; }

        [Display(Name = "ECP код")]
        [Required(ErrorMessage = "Введите Ecp код станции")]
        public int EcpCode { get; set; }

        [Display(Name = "Название")]
        [Required(ErrorMessage = "Введите название станции")]
        public string Name { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }


       // public virtual ICollection<RegulatoryScheduleDto> RegulatoryScheduleDispatchStations { get; set; }        //Один ко многим RegulatoryScheduleDto.DispatchStations

        //public virtual ICollection<RegulatoryScheduleDto> RegulatoryScheduleDestinationStations { get; set; }     //Один ко многим RegulatoryScheduleDto.DestinationStations


        //public virtual List<RegShStationsListOfStops> RegulatorySchedulesListOfStops { get; set; }             //Многие ко многим с RegulatoryScheduleDto.ListOfStops

        //public virtual List<RegShStationsListWithOutStops> RegulatorySchedulesListWithoutStops { get; set; }   //Многие ко многим с RegulatoryScheduleDto.ListWithoutStops 


        //public virtual ICollection<OperativeScheduleDto> OperativeSchedulesListOfStops { get; set; }            //Многие ко многим с OperativeScheduleDto.ListOfStops

        //public virtual ICollection<OperativeScheduleDto> OperativeSchedulesListWithoutStops { get; set; }       //Многие ко многим с OperativeScheduleDto.ListWithoutStops 




       // public virtual ICollection<RailwayStationViewModel> RailwayStations { get; set; }                      //Многие ко многим с RailwayStationDto (для вывода всех станций по вокзалу) 
    }
}