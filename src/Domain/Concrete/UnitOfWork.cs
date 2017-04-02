using System.Threading.Tasks;
using Domain.Abstract;
using Domain.DbContext;
using Domain.Entities;

namespace Domain.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CisDbContext _context;

        private GenericRepository<StationDto> _stationRepository;
        private GenericRepository<RegulatoryScheduleDto> _regulatoryScheduleRepository;
        private GenericRepository<OperativeScheduleDto> _operativeScheduleRepository;
        private GenericRepository<RailwayStationDto> _railwayStationRepository;
        private GenericRepository<DiagnosticDto> _diagnosticRepository;
        private GenericRepository<InfoDto> _infoRepository;

        public IRepository<StationDto> StationRepository => _stationRepository ?? (_stationRepository = new GenericRepository<StationDto>(_context));
        public IRepository<RegulatoryScheduleDto> RegulatoryScheduleRepository => _regulatoryScheduleRepository ?? (_regulatoryScheduleRepository = new GenericRepository<RegulatoryScheduleDto>(_context));
        public IRepository<OperativeScheduleDto> OperativeScheduleRepository => _operativeScheduleRepository ?? (_operativeScheduleRepository = new GenericRepository<OperativeScheduleDto>(_context));
        public IRepository<RailwayStationDto> RailwayStationRepository => _railwayStationRepository ?? (_railwayStationRepository = new GenericRepository<RailwayStationDto>(_context));
        public IRepository<DiagnosticDto> DiagnosticRepository => _diagnosticRepository ?? (_diagnosticRepository = new GenericRepository<DiagnosticDto>(_context));
        public IRepository<InfoDto> InfoRepository => _infoRepository ?? (_infoRepository = new GenericRepository<InfoDto>(_context));



        public UnitOfWork(CisDbContext context)
        {
            _context = context;
        }




        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }


        public int Save()
        {
            return _context.SaveChanges();
        }


        public void UndoChanges()
        {
            foreach (var entity in _context.ChangeTracker.Entries())
            {
                entity.Reload();
            }
        }


        public void Dispose()
        {
            var hash = _context.GetHashCode(); //DEBUG


            _context.Dispose();
        }
    }
}