using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.Entities;

namespace WebCis.Model
{
    public class RailwayStationModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Введите название станции")]
        [MaxLength(100)]
        public string Name { get; set; }

        public ICollection<StationModel> Stations { get; set; }                          // многие ко многим с Station. (список возможных станций этого вокзала)

       // public virtual ICollection<RegulatorySchedule> RegulatorySchedules { get; set; }       // один ко многим с RegulatorySchedules. (одна запись в расписании принаджежит только 1 вокзалу)
    }
}