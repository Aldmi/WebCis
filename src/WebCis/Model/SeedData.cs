using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Abstract;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebCis.Controllers;

namespace WebCis.Model
{
    public static class SeedData
    {
        public static async Task Initialize(IUnitOfWork unitOfWork)
        {
            try
            {
                using (var uow = unitOfWork)
                {
                    if (!await uow.RailwayStationRepository.Get().AnyAsync())
                    {
                        var railwaySt = new RailwayStationDto { Name = "Ленинградский" };
                        uow.RailwayStationRepository.Insert(railwaySt);

                        railwaySt.Stations = new List<RailwayStStationStations>
                        {
                           new RailwayStStationStations
                            {
                                RailwayStationDto = railwaySt,
                                StationDto = new StationDto
                                {
                                    Name = "НЕИЗВЕСТНО",
                                    EcpCode = 0,
                                }
                            },
                            new RailwayStStationStations
                            {
                                RailwayStationDto = railwaySt,
                                StationDto = new StationDto
                                {
                                    Name = "Станция 1",
                                    Description = " Описание Станции 1",
                                    EcpCode = 1111,
                                }
                            },
                            new RailwayStStationStations
                            {
                                RailwayStationDto = railwaySt,
                                StationDto = new StationDto
                                {
                                    Name = "Станция 2",
                                    Description = " Описание Станции 2",
                                    EcpCode = 2222,
                                }
                            },
                            new RailwayStStationStations
                            {
                                RailwayStationDto = railwaySt,
                                StationDto = new StationDto
                                {
                                    Name = "Станция 3",
                                    Description = " Описание Станции 3",
                                    EcpCode = 3333,
                                }
                            },
                            new RailwayStStationStations
                            {
                                RailwayStationDto = railwaySt,
                                StationDto = new StationDto
                                {
                                    Name = "Станция 4",
                                    Description = " Описание Станции 4",
                                    EcpCode = 4444,
                                }
                            },
                        };

                        await uow.SaveAsync();

                    }


                    if (!await uow.RegulatoryScheduleRepository.Get().AnyAsync())
                    {
                        var railwatSt = await uow.RailwayStationRepository.Get().FirstAsync();
                        var unknownSt = await uow.StationRepository.Get().FirstOrDefaultAsync(st => st.Name == "НЕИЗВЕСТНО");

                        if(unknownSt == null)
                            return;

                        var listRegSh = new List<RegulatoryScheduleDto>{
                        new RegulatoryScheduleDto
                        {
                            RailwayStId = railwatSt.Id,
                            ArrivalTime = DateTime.MaxValue,
                            DepartureTime = DateTime.Now,
                            DaysFollowings = "Ежедневно",
                            NumberOfTrain = "152",
                            RouteName = "Москва-Питер",
                            DestinationStationDto = unknownSt,
                            DispatchStationDto = unknownSt
                        },
                        new RegulatoryScheduleDto
                        {
                            RailwayStId = railwatSt.Id,
                            ArrivalTime = DateTime.MinValue,
                            DepartureTime = new DateTime(2017, 5, 12),
                            DaysFollowings = "Ежедневно",
                            NumberOfTrain = "169",
                            RouteName = "Тверь-Воркута",
                            DestinationStationDto = unknownSt,
                            DispatchStationDto = unknownSt
                        },
                        new RegulatoryScheduleDto
                        {
                            RailwayStId = railwatSt.Id,
                            ArrivalTime = new DateTime(2017, 7, 25),
                            DepartureTime = DateTime.Now,
                            DaysFollowings = "Кроме выходных",
                            NumberOfTrain = "1623",
                            RouteName = "Тверь-Воркута",
                            DestinationStationDto = unknownSt,
                            DispatchStationDto = unknownSt
                        }
                        };


                        uow.RegulatoryScheduleRepository.InsertRange(listRegSh);
                        await uow.SaveAsync();
                    }



                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

    }
}