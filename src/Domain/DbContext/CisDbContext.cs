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

        public DbSet<Station> Stations { get; set; }

        public DbSet<RegulatorySchedule> RegulatorySchedules { get; set; }

        //public DbSet<OperativeSchedule> OperativeSchedules { get; set; }

        public DbSet<RailwayStation> RailwayStations { get; set; }

        //public DbSet<Info> Infos { get; set; }

        public DbSet<Diagnostic> Diagnostics { get; set; }

        #endregion




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //RegulatorySchedule-----------------------------------------------
            modelBuilder.Entity<RegulatorySchedule>()
                .HasOne(s => s.DestinationStation)
                .WithMany(s => s.RegulatoryScheduleDestinationStations)
                .HasForeignKey(s=>s.DestId)
                .OnDelete(DeleteBehavior.Restrict);                         //SQl сервер не поддерживает каскадное удаление при наличии нескольких связе 1 ко многим для одного типа

            modelBuilder.Entity<RegulatorySchedule>()
                .HasOne(s => s.DispatchStation)
                .WithMany(s => s.RegulatoryScheduleDispatchStations)
                .HasForeignKey(s => s.DispId)
                .OnDelete(DeleteBehavior.Restrict);


            // M2M RegulatorySchedule.ListOfStops <---> Stations
            modelBuilder.Entity<RegShStationsListOfStops>()
                .HasKey(t => new {t.RegShId, StationId = t.StatId});        //SQl сервер поддерживает каскадное удаление

            modelBuilder.Entity<RegShStationsListOfStops>()
                .HasOne(r => r.RegulatorySchedule)
                .WithMany(r => r.ListOfStops)
                .HasForeignKey(r => r.RegShId);

            modelBuilder.Entity<RegShStationsListOfStops>()
                .HasOne(r => r.Station)
                .WithMany(r => r.RegulatorySchedulesListOfStops)
                .HasForeignKey(r => r.StatId);


            // M2M RegulatorySchedule.ListWithoutStops <---> Stations
            modelBuilder.Entity<RegShStationsListWithOutStops>()
                .HasKey(t => new { t.RegShId, StationId = t.StatId });      //SQl сервер поддерживает каскадное удаление

            modelBuilder.Entity<RegShStationsListWithOutStops>()
                .HasOne(r => r.RegulatorySchedule)
                .WithMany(r => r.ListWithoutStops)
                .HasForeignKey(r => r.RegShId);

            modelBuilder.Entity<RegShStationsListWithOutStops>()
                .HasOne(r => r.Station)
                .WithMany(r => r.RegulatorySchedulesListWithoutStops)
                .HasForeignKey(r => r.StatId);



            //RailwayStation-----------------------------------------------
            modelBuilder.Entity<RailwayStation>()
                .HasMany(r => r.RegulatorySchedules)
                .WithOne(r => r.RailwayStation)
                .HasForeignKey(r => r.RailwayStId)
                .IsRequired();


            // M2M RailwayStation.Stations <---> Station.RailwayStations
            modelBuilder.Entity<RailwayStStationStations>()
                .HasKey(t => new { t.RailStId, StationId = t.StatId });      //SQl сервер поддерживает каскадное удаление

            modelBuilder.Entity<RailwayStStationStations>()
                .HasOne(r => r.RailwayStation)
                .WithMany(r => r.Stations)
                .HasForeignKey(r => r.RailStId);

            modelBuilder.Entity<RailwayStStationStations>()
                .HasOne(r => r.Station)
                .WithMany(r => r.RailwayStations)
                .HasForeignKey(r => r.StatId);
        }
    }
}