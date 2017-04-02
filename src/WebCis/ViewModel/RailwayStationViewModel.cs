using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebCis.Model;

namespace WebCis.ViewModel
{
    public class RailwayStationViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Введите название станции")]
        [MaxLength(100)]
        public string Name { get; set; }

        public ICollection<StationViewModel> Stations { get; set; }                          // многие ко многим с StationDto. (список возможных станций этого вокзала)

       // public virtual ICollection<RegulatoryScheduleDto> RegulatorySchedules { get; set; }       // один ко многим с RegulatorySchedules. (одна запись в расписании принаджежит только 1 вокзалу)
    }
}