using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace BusinessLayer
{
    public interface IDomainAcessLayer
    {
        Task<IList<Station>> GetAllStationByRailwayStationName(string nameRailwayStation);
    }
}