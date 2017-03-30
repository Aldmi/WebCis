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

                return railwayStation?.Stations.Select(st => st.Station).ToList();
            }
        }

        #endregion

    }
}