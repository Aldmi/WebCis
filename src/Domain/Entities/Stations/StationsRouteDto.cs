using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities.Schedules;


namespace Domain.Entities
{
    public class StationsRouteDto : IEntitie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public bool IsLanding { get; set; }                                               //флаг посадки.

        [Column(TypeName = "datetime2")]
        public DateTime? ArrivalTime { get; set; }                                         //Время прибытия поезда на станцию

        [Column(TypeName = "datetime2")]
        public DateTime? DepartureTime { get; set; }                                       //Время отправления поезда со станции


        public int StationDtoId { get; set; }
        public StationDto StationDto { get; set; }                                         //Станция

        public ICollection<RegShStationsRouteRoutes> RegShRoutes{ get; set; }               //Расписание, в которые входят данные станции
    }
}