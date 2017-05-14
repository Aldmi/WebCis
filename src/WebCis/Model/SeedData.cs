using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Abstract;
using Domain.Entities;
using Domain.Entities.RailwayStations;
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

                        //------------------------------------
                        var stations = await uow.StationRepository.Get().Where(st => true).ToListAsync();
                        var routeStations= stations.Select(st=> new StationsRouteDto {StationDto = st, IsLanding = true, ArrivalTime = DateTime.Now}).ToList();
                        var regSh = new RegulatoryScheduleDto
                        {
                            RailwayStId = railwatSt.Id,
                            ArrivalTime = DateTime.MaxValue,
                            DepartureTime = DateTime.Now,
                            DaysFollowings = "Ежедневно",
                            NumberOfTrain = "152",
                            RouteName = "Москва-Питер",
                            DestinationStationDto = unknownSt,
                            DispatchStationDto = unknownSt,
                        };


                        var routes = routeStations.Select(rs=> new RegShStationsRouteRoutes {StationRouteDto = rs, RegulatoryScheduleDto =  regSh}).ToList();
                        regSh.Route = routes;

                        uow.RegulatoryScheduleRepository.Insert(regSh);
                        await uow.SaveAsync();
                    }



                    if (!await uow.StationRouteRepository.Get().AnyAsync())
                    {
                        var station = await uow.StationRepository.Get().FirstOrDefaultAsync(st => st.Name == "Станция 1");
                        if (station != null)
                        {
                            var stRoute = new StationsRouteDto()
                            {
                                IsLanding = true,
                                StationDtoId = station.Id,
                                ArrivalTime = DateTime.Now
                            };
                            uow.StationRouteRepository.Insert(stRoute);
                            await uow.SaveAsync();
                        }
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