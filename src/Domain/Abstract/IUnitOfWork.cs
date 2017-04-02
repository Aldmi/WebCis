using System;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<StationDto> StationRepository { get; }                                 //Станции

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