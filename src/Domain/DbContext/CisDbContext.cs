using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;


namespace Domain.DbContext
{
    public class CisDbContext : Microsoft.EntityFrameworkCore.DbContext
    {

        public CisDbContext(DbContextOptions<CisDbContext> options)
            : base(options)
        {
        }




        #region Reps

        public DbSet<StationDto> Stations { get; set; }

        public DbSet<RegulatoryScheduleDto> RegulatorySchedules { get; set; }

        //public DbSet<OperativeScheduleDto> OperativeSchedules { get; set; }

        public DbSet<RailwayStationDto> RailwayStations { get; set; }

        //public DbSet<InfoDto> Infos { get; set; }

        public DbSet<DiagnosticDto> Diagnostics { get; set; }

        #endregion




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //RegulatoryScheduleDto-----------------------------------------------
            modelBuilder.Entity<RegulatoryScheduleDto>()
                .HasOne(s => s.DestinationStationDto)
                .WithMany(s => s.RegulatoryScheduleDestinationStations)
                .HasForeignKey(s=>s.DestId)
                .OnDelete(DeleteBehavior.Restrict);                         //SQl сервер не поддерживает каскадное удаление при наличии нескольких связе 1 ко многим для одного типа

            modelBuilder.Entity<RegulatoryScheduleDto>()
                .HasOne(s => s.DispatchStationDto)
                .WithMany(s => s.RegulatoryScheduleDispatchStations)
                .HasForeignKey(s => s.DispId)
                .OnDelete(DeleteBehavior.Restrict);


            // M2M RegulatoryScheduleDto.ListOfStops <---> Stations
            modelBuilder.Entity<RegShStationsListOfStops>()
                .HasKey(t => new {t.RegShId, StationId = t.StatId});        //SQl сервер поддерживает каскадное удаление

            modelBuilder.Entity<RegShStationsListOfStops>()
                .HasOne(r => r.RegulatoryScheduleDto)
                .WithMany(r => r.ListOfStops)
                .HasForeignKey(r => r.RegShId);

            modelBuilder.Entity<RegShStationsListOfStops>()
                .HasOne(r => r.StationDto)
                .WithMany(r => r.RegulatorySchedulesListOfStops)
                .HasForeignKey(r => r.StatId);


            // M2M RegulatoryScheduleDto.ListWithoutStops <---> Stations
            modelBuilder.Entity<RegShStationsListWithOutStops>()
                .HasKey(t => new { t.RegShId, StationId = t.StatId });      //SQl сервер поддерживает каскадное удаление

            modelBuilder.Entity<RegShStationsListWithOutStops>()
                .HasOne(r => r.RegulatoryScheduleDto)
                .WithMany(r => r.ListWithoutStops)
                .HasForeignKey(r => r.RegShId);

            modelBuilder.Entity<RegShStationsListWithOutStops>()
                .HasOne(r => r.StationDto)
                .WithMany(r => r.RegulatorySchedulesListWithoutStops)
                .HasForeignKey(r => r.StatId);



            //RailwayStationDto-----------------------------------------------
            modelBuilder.Entity<RailwayStationDto>()
                .HasMany(r => r.RegulatorySchedules)
                .WithOne(r => r.RailwayStationDto)
                .HasForeignKey(r => r.RailwayStId)
                .IsRequired();


            // M2M RailwayStationDto.Stations <---> StationDto.RailwayStations
            modelBuilder.Entity<RailwayStStationStations>()
                .HasKey(t => new { t.RailStId, StationId = t.StatId });      //SQl сервер поддерживает каскадное удаление

            modelBuilder.Entity<RailwayStStationStations>()
                .HasOne(r => r.RailwayStationDto)
                .WithMany(r => r.Stations)
                .HasForeignKey(r => r.RailStId);

            modelBuilder.Entity<RailwayStStationStations>()
                .HasOne(r => r.StationDto)
                .WithMany(r => r.RailwayStations)
                .HasForeignKey(r => r.StatId);
        }
    }
}