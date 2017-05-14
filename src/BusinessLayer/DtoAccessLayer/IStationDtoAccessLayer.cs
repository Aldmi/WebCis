using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;


namespace BusinessLayer.DtoAccessLayer
{
    public interface IStationDtoAccessLayer
    {
        Task<IList<StationDto>> GetAllStation(string nameRailwayStation);
        Task<StationDto> GetStationById(int id, string nameRailwayStation = null);

        Task AddNewStation(StationDto stationDto, string nameRailwayStation);
        Task AddNewStation(StationDto stationDto, int idRailwayStation);

        Task<bool> EditStation(StationDto stationDto);

        Task<bool> RemoveStationById(int id);
        Task<bool> RemoveStation(StationDto stationDto);
    }


    public enum ChangeDbResult { Success, DeleteError, EditError } //TODO: возврощать в операциях изменения домена, вместо Task<bool>.

}