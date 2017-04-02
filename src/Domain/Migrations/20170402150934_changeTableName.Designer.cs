using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Domain.DbContext;

namespace Domain.Migrations
{
    [DbContext(typeof(CisDbContext))]
    [Migration("20170402150934_changeTableName")]
    partial class changeTableName
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Entities.DiagnosticDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeviceName");

                    b.Property<int>("DeviceNumber");

                    b.Property<string>("Fault");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.ToTable("Diagnostics");
                });

            modelBuilder.Entity("Domain.Entities.RailwayStationDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("RailwayStations");
                });

            modelBuilder.Entity("Domain.Entities.RailwayStStationStations", b =>
                {
                    b.Property<int>("RailStId");

                    b.Property<int>("StatId");

                    b.HasKey("RailStId", "StatId");

                    b.HasIndex("StatId");

                    b.ToTable("RailwayStStationStations");
                });

            modelBuilder.Entity("Domain.Entities.RegShStationsListOfStops", b =>
                {
                    b.Property<int>("RegShId");

                    b.Property<int>("StatId");

                    b.HasKey("RegShId", "StatId");

                    b.HasIndex("StatId");

                    b.ToTable("RegShStationsListOfStops");
                });

            modelBuilder.Entity("Domain.Entities.RegShStationsListWithOutStops", b =>
                {
                    b.Property<int>("RegShId");

                    b.Property<int>("StatId");

                    b.HasKey("RegShId", "StatId");

                    b.HasIndex("StatId");

                    b.ToTable("RegShStationsListWithOutStops");
                });

            modelBuilder.Entity("Domain.Entities.RegulatoryScheduleDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("ArrivalTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("DaysFollowings");

                    b.Property<DateTime?>("DepartureTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("DestId");

                    b.Property<int>("DispId");

                    b.Property<string>("NumberOfTrain")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<int>("RailwayStId");

                    b.Property<string>("RouteName")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("DestId");

                    b.HasIndex("DispId");

                    b.HasIndex("RailwayStId");

                    b.ToTable("RegulatorySchedules");
                });

            modelBuilder.Entity("Domain.Entities.StationDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<int>("EcpCode");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Stations");
                });

            modelBuilder.Entity("Domain.Entities.RailwayStStationStations", b =>
                {
                    b.HasOne("Domain.Entities.RailwayStationDto", "RailwayStationDto")
                        .WithMany("Stations")
                        .HasForeignKey("RailStId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Entities.StationDto", "StationDto")
                        .WithMany("RailwayStations")
                        .HasForeignKey("StatId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Entities.RegShStationsListOfStops", b =>
                {
                    b.HasOne("Domain.Entities.RegulatoryScheduleDto", "RegulatoryScheduleDto")
                        .WithMany("ListOfStops")
                        .HasForeignKey("RegShId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Entities.StationDto", "StationDto")
                        .WithMany("RegulatorySchedulesListOfStops")
                        .HasForeignKey("StatId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Entities.RegShStationsListWithOutStops", b =>
                {
                    b.HasOne("Domain.Entities.RegulatoryScheduleDto", "RegulatoryScheduleDto")
                        .WithMany("ListWithoutStops")
                        .HasForeignKey("RegShId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Entities.StationDto", "StationDto")
                        .WithMany("RegulatorySchedulesListWithoutStops")
                        .HasForeignKey("StatId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Entities.RegulatoryScheduleDto", b =>
                {
                    b.HasOne("Domain.Entities.StationDto", "DestinationStationDto")
                        .WithMany("RegulatoryScheduleDestinationStations")
                        .HasForeignKey("DestId");

                    b.HasOne("Domain.Entities.StationDto", "DispatchStationDto")
                        .WithMany("RegulatoryScheduleDispatchStations")
                        .HasForeignKey("DispId");

                    b.HasOne("Domain.Entities.RailwayStationDto", "RailwayStationDto")
                        .WithMany("RegulatorySchedules")
                        .HasForeignKey("RailwayStId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
