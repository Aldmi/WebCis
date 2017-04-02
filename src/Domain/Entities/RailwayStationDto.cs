using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace Domain.Entities
{
    /// <summary>
    /// Вокзал.
    /// </summary>
    public class RailwayStationDto : IEntitie
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public virtual ICollection<RailwayStStationStations> Stations { get; set; }              // многие ко многим с StationDto. (список возможных станций этого вокзала)

        public virtual ICollection<RegulatoryScheduleDto> RegulatorySchedules { get; set; }         // один ко многим с RegulatorySchedules. (одна запись в расписании принаджежит только 1 вокзалу)

        //public virtual ICollection<OperativeScheduleDto> OperativeSchedules { get; set; }         // один ко многим с  OperativeScheduleDto. (одна запись в расписании принаджежит только 1 вокзалу)


        //public virtual ICollection<InfoDto> Infos { get; set; }

        //public virtual ICollection<DiagnosticDto> Diagnostics { get; set; }                       // один ко многим с DiagnosticDto. (одна запись в диагностики принаджежит только 1 вокзалу)
    }
}