﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace Domain.Entities
{
    /// <summary>
    /// Вокзал.
    /// </summary>
    public class RailwayStation : IEntitie
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Введите название станции")]
        [MaxLength(100)]
        public string Name { get; set; }

        public virtual IEnumerable<RailwayStStationStations> Stations { get; set; }               // многие ко многим с Station. (список возможных станций этого вокзала)

        public virtual ICollection<RegulatorySchedule> RegulatorySchedules { get; set; }         // один ко многим с RegulatorySchedules. (одна запись в расписании принаджежит только 1 вокзалу)

        //public virtual ICollection<OperativeSchedule> OperativeSchedules { get; set; }         // один ко многим с  OperativeSchedule. (одна запись в расписании принаджежит только 1 вокзалу)


        //public virtual ICollection<Info> Infos { get; set; }

        //public virtual ICollection<Diagnostic> Diagnostics { get; set; }                       // один ко многим с Diagnostic. (одна запись в диагностики принаджежит только 1 вокзалу)
    }
}