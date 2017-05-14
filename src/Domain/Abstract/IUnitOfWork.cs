using System;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Entities.RailwayStations;
using Domain.Entities.Schedules;


namespace Domain.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<StationDto> StationRepository { get; }                                 //Станции

        IRepository<StationsRouteDto> StationRouteRepository { get; }                      //Станции учавствуюшие в постоении маршрута

        IRepository<RegulatoryScheduleDto> RegulatoryScheduleRepository { get; }           //Регулярное расписание

        IRepository<OperativeScheduleDto> OperativeScheduleRepository { get; }             //Оперативное расписание

        IRepository<RailwayStationDto> RailwayStationRepository { get; }                   //Вокзалы

        IRepository<DiagnosticDto> DiagnosticRepository { get; }                           //Диагностика оборудования автодиктора

        IRepository<InfoDto> InfoRepository { get; }                                       //Оперативная информация про поезда




        int Save();
        Task<int> SaveAsync();

        void UndoChanges();
    }
}