﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    /// <summary>
    /// Нормативное расписание поездов.
    /// Нормативное расписание движения поездов содержит сведения обо всех пассажирских и пригородных поездах следующих по станции с учетом вводимых изменений.
    /// Глубина предоставления нормативного  расписания по умолчанию составляет:
    ///	для пассажирских поездов – 60 суток;
    ///	для пригородных поездов – 21 суток.
    /// Данные нормативного расписания предназначены для формирования информации на табло с общим расписанием движения поездов по станции
    /// Пересчет нормативного расписания осуществляется один раз в сутки.
    /// </summary>
    public class RegulatorySchedule : IEntitie
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(10)]
        public string NumberOfTrain { get; set; }                   //Номер поезда в расписании

        [MaxLength(100)]
        public string RouteName { get; set; }                       //Станция отправления и станция назначения, а также фирменное название поезда, если есть.

        public string DaysFollowings { get; set; }                  //Дни следования поезда(ежедневно, четные, по рабочим и т.п.)

        [Column(TypeName = "datetime2")]
        public DateTime? ArrivalTime { get; set; }                  //Время прибытия поезда на станцию

        [Column(TypeName = "datetime2")]
        public DateTime? DepartureTime { get; set; }                //Время отправления поезда со станции


        public int DispId { get; set; }
        public virtual Station DispatchStation { get; set; }        //Станция отправления

        public int DestId { get; set; }
        public virtual Station DestinationStation { get; set; }     //Станция назначения


        public virtual List<RegShStationsListOfStops> ListOfStops { get; set; }           //Список станций где останавливается поезд (Заполнятся только для пригородных поездов)

        public virtual List<RegShStationsListWithOutStops> ListWithoutStops { get; set; } //Список станций которые поезд проезжает без остановки (Заполнятся только для пригородных поездов)


        public int RailwayStId { get; set; }
        public virtual RailwayStation RailwayStation { get; set; }        //Обязательно относится к вокзалу     
    }

}