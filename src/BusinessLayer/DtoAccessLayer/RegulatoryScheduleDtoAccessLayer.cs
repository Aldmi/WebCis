using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Concrete;
using Domain.DbContext;
using Domain.Entities;

using Microsoft.EntityFrameworkCore;


namespace BusinessLayer.DtoAccessLayer
{
    public class RegulatoryScheduleDtoAccessLayer
    {
        #region fields

        private readonly DbContextOptionsBuilder<CisDbContext> _optionsBuilder;

        #endregion





        #region ctor

        public RegulatoryScheduleDtoAccessLayer(string connectionDomain)
        {
            _optionsBuilder = new DbContextOptionsBuilder<CisDbContext>();
            _optionsBuilder.UseSqlServer(connectionDomain);
        }

        #endregion






        #region Methode

        public async Task<IList<RegulatoryScheduleDto>> GetAllRegSh(string nameRailwayStation)
        {
            using (var uow = new UnitOfWork(new CisDbContext(_optionsBuilder.Options)))
            {
                var railwayStation = await uow.RailwayStationRepository.Get().
                    Include(reg => reg.RegulatorySchedules).
                    ThenInclude(reg => reg.DestinationStationDto).

                    Include(reg => reg.RegulatorySchedules).
                    ThenInclude(reg => reg.DispatchStationDto).

                    Include(reg=>reg.RegulatorySchedules).
                    ThenInclude(reg => reg.ListOfStops).
                    ThenInclude(st=>st.StationDto).

                    Include(reg => reg.RegulatorySchedules).
                    ThenInclude(reg => reg.ListWithoutStops).
                    ThenInclude(st => st.StationDto).

                    AsNoTracking().
                    FirstOrDefaultAsync(n => n.Name.Equals(nameRailwayStation));

                return railwayStation.RegulatorySchedules.ToList();
            }
        }


        /// <summary>
        /// Получить станцию по Id из всего репозитория Станций.
        /// Если указанно имя вокзала, то вначале отфильтровать станции относяшиеся к этому вокзалу.
        /// </summary>
        public async Task<StationDto> GetStationById(int id, string nameRailwayStation = null)
        {
            using (var uow = new UnitOfWork(new CisDbContext(_optionsBuilder.Options)))
            {
                if (string.IsNullOrEmpty(nameRailwayStation))
                {
                    return await uow.StationRepository.GetByIdAsync(id);
                }

                var railwayStation = await uow.RailwayStationRepository.Get().
                    Include(st => st.Stations).
                    ThenInclude(st => st.StationDto).
                    AsNoTracking().
                    FirstOrDefaultAsync(n => n.Name.Equals(nameRailwayStation));


                return railwayStation?.Stations.FirstOrDefault(st => st.StatId == id)?.StationDto;
            }
        }



        public async Task AddNewRegSh(RegulatoryScheduleDto regShDto, string nameRailwayStation)
        {
            using (var uow = new UnitOfWork(new CisDbContext(_optionsBuilder.Options)))
            {
                if (string.IsNullOrEmpty(nameRailwayStation))
                    return;

                if (regShDto == null)
                    return;

                var railwayStation = await uow.RailwayStationRepository.Get().Include(rs => rs.RegulatorySchedules).FirstOrDefaultAsync(n => n.Name.Equals(nameRailwayStation));
                if (railwayStation != null)
                {
                    regShDto.RailwayStId = railwayStation.Id;
                    railwayStation.RegulatorySchedules.Add(regShDto);

                    await uow.SaveAsync();
                }
            }
        }



        public async Task<bool> EditStation(StationDto stationDto)
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



        public async Task<bool> RemoveStationById(int id)
        {
            using (var uow = new UnitOfWork(new CisDbContext(_optionsBuilder.Options)))
            {
                try
                {
                    var station = await uow.StationRepository.GetByIdAsync(id);
                    if (station != null)
                    {
                        uow.StationRepository.Remove(station);
                        await uow.SaveAsync();
                        return true;
                    }
                    return false;
                }
                catch (DbUpdateConcurrencyException)
                {
                    var findStation = uow.StationRepository.GetById(id);
                    if (findStation != null)         //уже удалили из паралельного потока
                    {
                        return false;
                    }
                    throw;
                }
            }
        }



        public async Task<bool> RemoveStation(StationDto stationDto)
        {
            using (var uow = new UnitOfWork(new CisDbContext(_optionsBuilder.Options)))
            {
                try
                {
                    if (stationDto != null && await uow.StationRepository.Exists(stationDto))
                    {
                        uow.StationRepository.Remove(stationDto);
                        await uow.SaveAsync();
                        return true;
                    }
                    return false;
                }
                catch (DbUpdateConcurrencyException)
                {
                    var findStation = uow.StationRepository.GetById(stationDto.Id);
                    if (findStation != null)         //уже удалили из паралельного потока
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
