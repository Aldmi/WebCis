using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer;
using Domain.Abstract;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WebCis.Model;
using WebCis.Settings;


namespace WebCis.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDomainAcessLayer _domainAcessLayer;
        private readonly IMapper _mapper;
        private readonly MainSetting _settingsOptions;




        public HomeController(IDomainAcessLayer domainAcessLayer, IOptions<MainSetting> settingsOptions, IMapper mapper)
        {
            _domainAcessLayer = domainAcessLayer;
            _settingsOptions = settingsOptions.Value;
            _mapper = mapper;
        }





        public async Task<IActionResult> Index()
        {
            //var stations = await _unitOfWork.StationRepository.Get().ToListAsync();

            //var stations= await _domainAcessLayer.GetAllStation("Ленинградский");
            //if (stations != null)
            //{
            //    var railwayStationStationsModel = _mapper.Map<List<StationViewModel>>(stations);
            //}



            //var railwayStation = await _unitOfWork.RailwayStationRepository.Get().
            //    Include(st => st.Stations).
            //    ThenInclude(st => st.StationDto).
            //    AsNoTracking().
            //    FirstOrDefaultAsync(n => n.Name.Equals("Ленинградский"));

            //var railwayStationStations = railwayStation?.Stations.Select(st => st.StationDto).ToList();
            //if (railwayStationStations != null)
            //{
            //    var railwayStationStationsModel = _mapper.Map<List<StationViewModel>>(railwayStationStations);
            //}

            return View();
        }




        public async Task<IActionResult> About()
        {
            //test добавление новой станции в вокзал

            //StationViewModel stationModel = new StationViewModel { EcpCode = 98521, Name = "НоваяСтанция1", Description = "Описание новой станции1" };
            //StationDto stationDtoDto = _mapper.Map<StationDto>(stationModel);
            //var railwayStation = await _unitOfWork.RailwayStationRepository.Get().FirstOrDefaultAsync(n => n.Name.Equals("Ленинградский"));
            //railwayStation.Stations.Add(new RailwayStStationStations { RailStId = railwayStation.Id, StationDto = stationDtoDto });

            //await _unitOfWork.SaveAsync();




            ViewData["Message"] = "Your application description page.";
            return View();
        }


        public async Task<IActionResult> Contact()
        {
            //test изменение станции в вокзале

            int stationId = 10;

            //var railwayStation = await _unitOfWork.RailwayStationRepository.Get().
            //    Include(st => st.Stations).
            //    FirstOrDefaultAsync(n => n.Name.Equals("Ленинградский"));


            //var stationDto = _unitOfWork.StationRepository.GetById(stationId);

            //stationDto.Name = "Измененное имя станции1";
            //_unitOfWork.StationRepository.Update(stationDto);
            //await _unitOfWork.SaveAsync();

            ViewData["Message"] = "Your contact page.";
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }

}
