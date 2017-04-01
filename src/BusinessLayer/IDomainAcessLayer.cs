using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace BusinessLayer
{
    public interface IDomainAcessLayer
    {
        Task<IList<Station>> GetAllStationByRailwayStationName(string nameRailwayStation);
        Task<Station> GetStationById(int id, string nameRailwayStation = null);

        Task AddNewStation(Station stationDto, string nameRailwayStation);
        Task AddNewStation(Station stationDto, int idRailwayStation);

        Task<bool> EditStation(Station stationDto);
    }
}