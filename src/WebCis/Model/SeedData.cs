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
                    if (await uow.RailwayStationRepository.Get().AnyAsync())
                    {
                        return; // DB has been seeded
                    }

                    var railwaySt = new RailwayStation { Name = "Ленинградский" };
                    uow.RailwayStationRepository.Insert(railwaySt);


                    railwaySt.Stations = new List<RailwayStStationStations>
                    {
                      new RailwayStStationStations
                    {
                        RailwayStation = railwaySt,
                        Station = new Station
                        {
                            Name = "Станция 1",
                            Description = " Описание Станции 1",
                            EcpCode = 1111,
                        }
                    },
                     new RailwayStStationStations
                    {
                        RailwayStation = railwaySt,
                        Station = new Station
                        {
                            Name = "Станция 2",
                            Description = " Описание Станции 2",
                            EcpCode = 2222,
                        }
                    },
                     new RailwayStStationStations
                    {
                        RailwayStation = railwaySt,
                        Station = new Station
                        {
                            Name = "Станция 3",
                            Description = " Описание Станции 3",
                            EcpCode = 3333,
                        }
                    },
                    new RailwayStStationStations
                    {
                        RailwayStation = railwaySt,
                        Station = new Station
                        {
                            Name = "Станция 4",
                            Description = " Описание Станции 4",
                            EcpCode = 4444,
                        }
                    },
                };

                    await uow.SaveAsync();

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

    }
}