using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    /// <summary>
    /// Номер пути прибытия и время опоздания.
    /// Данные информационного потока предназначены для формирования информации на  табло содержащих сведения о  ближайших поездах, а также платформенных указателях. 
    /// Пересчет данных номера пути(платформы) прибытия и времени опоздания производится непрерывно в режиме реального времени для поездов из списка оперативного расписанияиз списка оперативного расписания.
    /// Не содержит поезда уже прибывшие или отправившиеся  со станции. 
    /// </summary>
    public class InfoDto : IEntitie
    {
        [Key]
        public int Id { get; set; }

        public virtual StationDto DispatchStationDto { get; set; }       //Станция отправления

        public virtual StationDto DestinationStationDto { get; set; }    //Станция назначения

        [Column(TypeName = "datetime2")]
        public DateTime? ArrivalTime { get; set; }                 //Время прибытия поезда на станцию

        [Column(TypeName = "datetime2")]
        public DateTime? DepartureTime { get; set; }               //Время отправления поезда со станции

        [Range(0, 100)]
        public int Platform { get; set; }                         //Номер платформы прибытия поезда, если еще неизвестен, то равен 0.

        [Required]
        [Range(0, 100)]
        public int Way { get; set; }                              //Номер пути прибытия поезда, если еще неизвестен, то равен 0.

        [Required]
        [MaxLength(100)]
        public string RouteName { get; set; }                     //Станция отправления и станция назначения, а также фирменное название поезда, если есть.

        [Range(0, 59)]
        public int Lateness { get; set; }                         //Количество минут опоздания от графика движения
    }
}