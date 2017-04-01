using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Abstract;
using Domain.Concrete;
using Domain.DbContext;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace BusinessLayer
{
    public class DomainAcessLayer : IDomainAcessLayer
    {
        private readonly DbContextOptionsBuilder<CisDbContext> _optionsBuilder;





        #region ctor

        public DomainAcessLayer(string connectionDomain)
        {
            _optionsBuilder = new DbContextOptionsBuilder<CisDbContext>();
            _optionsBuilder.UseSqlServer(connectionDomain);
        }

        #endregion






        #region Methode

        public async Task<IList<Station>> GetAllStationByRailwayStationName(string nameRailwayStation)
        {
            using (var uow = new UnitOfWork(new CisDbContext(_optionsBuilder.Options)))
            {
                var railwayStation = await uow.RailwayStationRepository.Get().
                    Include(st => st.Stations).
                    ThenInclude(st => st.Station).
                    AsNoTracking().
                    FirstOrDefaultAsync(n => n.Name.Equals(nameRailwayStation));

                return railwayStation.Stations.Select(st => st.Station).ToList();
            }
        }


        /// <summary>
        /// Получить станцию по Id из всего репозитория Станций.
        /// Если указанно имя вокзала, то вначале отфильтровать станции относяшиеся к этому вокзалу.
        /// </summary>
        public async Task<Station> GetStationById(int id, string nameRailwayStation = null)
        {
            using (var uow = new UnitOfWork(new CisDbContext(_optionsBuilder.Options)))
            {
                if (string.IsNullOrEmpty(nameRailwayStation))
                {
                    return await uow.StationRepository.GetByIdAsync(id);
                }

                var railwayStation = await uow.RailwayStationRepository.Get().
                    Include(st => st.Stations).
                    ThenInclude(st => st.Station).
                    AsNoTracking().
                    FirstOrDefaultAsync(n => n.Name.Equals(nameRailwayStation));


                return railwayStation?.Stations.FirstOrDefault(st => st.StatId == id)?.Station;
            }
        }



        public async Task AddNewStation(Station stationDto, string nameRailwayStation)
        {
            using (var uow = new UnitOfWork(new CisDbContext(_optionsBuilder.Options)))
            {
                if(string.IsNullOrEmpty(nameRailwayStation))
                    return;

                if(stationDto == null)
                    return;

                var railwayStation = await uow.RailwayStationRepository.Get().Include(rs=>rs.Stations).FirstOrDefaultAsync(n => n.Name.Equals("Ленинградский"));
                if (railwayStation != null)
                {
                    railwayStation.Stations.Add(new RailwayStStationStations
                    {
                        RailStId = railwayStation.Id,
                        Station = stationDto
                    });
                    await uow.SaveAsync();
                }
            }
        }


        public async Task AddNewStation(Station stationDto, int idRailwayStation)
        {
            using (var uow = new UnitOfWork(new CisDbContext(_optionsBuilder.Options)))
            {
                if (stationDto == null)
                    return;

                var railwayStation = await uow.RailwayStationRepository.GetByIdAsync(idRailwayStation);
                if (railwayStation != null)
                {
                    railwayStation.Stations.Add(new RailwayStStationStations
                    {
                        RailStId = railwayStation.Id,
                        Station = stationDto
                    });
                    await uow.SaveAsync();
                }
            }
        }


        public async Task<bool> EditStation(Station stationDto)
        {
            using (var uow = new UnitOfWork(new CisDbContext(_optionsBuilder.Options)))
            {
                try
                {
                    var findStation = uow.StationRepository.GetById(stationDto.Id);
                    if (findStation != null)
                    {
                        findStation = stationDto;
                        uow.StationRepository.Update(findStation);
                        await uow.SaveAsync();
                        return true;
                    }
                    return false;
                }
                catch (DbUpdateConcurrencyException)
                {
                    var findStation = uow.StationRepository.GetById(stationDto.Id);             
                    if (findStation != null)        //уже удалили из паралельного потока
                    {
                        return false;
                    }
                    throw;
                }
            }
        }







        #endregion

    }
}