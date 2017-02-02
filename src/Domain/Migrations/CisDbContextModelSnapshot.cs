using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Domain.DbContext;

namespace Domain.Migrations
{
    [DbContext(typeof(CisDbContext))]
    partial class CisDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Entities.Diagnostic", b =>
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

            modelBuilder.Entity("Domain.Entities.RailwayStation", b =>
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

            modelBuilder.Entity("Domain.Entities.RegulatorySchedule", b =>
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

            modelBuilder.Entity("Domain.Entities.Station", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<int>("EcpCode");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Stations");
                });

            modelBuilder.Entity("Domain.Entities.RailwayStStationStations", b =>
                {
                    b.HasOne("Domain.Entities.RailwayStation", "RailwayStation")
                        .WithMany("Stations")
                        .HasForeignKey("RailStId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Entities.Station", "Station")
                        .WithMany("RailwayStations")
                        .HasForeignKey("StatId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Entities.RegShStationsListOfStops", b =>
                {
                    b.HasOne("Domain.Entities.RegulatorySchedule", "RegulatorySchedule")
                        .WithMany("ListOfStops")
                        .HasForeignKey("RegShId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Entities.Station", "Station")
                        .WithMany("RegulatorySchedulesListOfStops")
                        .HasForeignKey("StatId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Entities.RegShStationsListWithOutStops", b =>
                {
                    b.HasOne("Domain.Entities.RegulatorySchedule", "RegulatorySchedule")
                        .WithMany("ListWithoutStops")
                        .HasForeignKey("RegShId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Entities.Station", "Station")
                        .WithMany("RegulatorySchedulesListWithoutStops")
                        .HasForeignKey("StatId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Entities.RegulatorySchedule", b =>
                {
                    b.HasOne("Domain.Entities.Station", "DestinationStation")
                        .WithMany("RegulatoryScheduleDestinationStations")
                        .HasForeignKey("DestId");

                    b.HasOne("Domain.Entities.Station", "DispatchStation")
                        .WithMany("RegulatoryScheduleDispatchStations")
                        .HasForeignKey("DispId");

                    b.HasOne("Domain.Entities.RailwayStation", "RailwayStation")
                        .WithMany("RegulatorySchedules")
                        .HasForeignKey("RailwayStId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
