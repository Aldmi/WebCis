using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace BusinessLayer
{
    public interface IDomainAcessLayer
    {
        Task<IList<StationDto>> GetAllStation(string nameRailwayStation);
        Task<StationDto> GetStationById(int id, string nameRailwayStation = null);

        Task AddNewStation(StationDto stationDtoDto, string nameRailwayStation);
        Task AddNewStation(StationDto stationDtoDto, int idRailwayStation);

        Task<bool> EditStation(StationDto stationDtoDto);

        Task<bool> RemoveStationById(int id);
        Task<bool> RemoveStation(StationDto stationDto);
    }


    public enum ChangeDbResult {DeleteError }

}