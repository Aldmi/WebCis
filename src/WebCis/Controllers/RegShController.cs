using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.DtoAccessLayer;
using Domain.Abstract;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;


namespace WebCis.Controllers
{
    public class RegShController : Controller
    {
        #region fileld

        private readonly RegulatoryScheduleDtoAccessLayer _regulatoryScheduleDtoAccessLayer;
        private readonly IMapper _mapper;

        #endregion





        #region ctor

        public RegShController(RegulatoryScheduleDtoAccessLayer regulatoryScheduleDtoAccessLayer, IMapper mapper)
        {
            _regulatoryScheduleDtoAccessLayer = regulatoryScheduleDtoAccessLayer;
            _mapper = mapper;
        }

        #endregion





        public async Task<IActionResult> Index()
        {
          var currenrRegSh= await _regulatoryScheduleDtoAccessLayer.GetAllRegSh("Ленинградский");


            //var listOfStops = new List<RegShStationsListOfStops>
            //{
            //    new RegShStationsListOfStops {StatId = 10},
            //    new RegShStationsListOfStops {StatId = 14}
            //};

            //var tempRegSh = new RegulatoryScheduleDto
            //{
            //    DestId = 9,
            //    DispId = 10,
            //    ArrivalTime = DateTime.Now,
            //    DepartureTime = DateTime.Now,
            //    DaysFollowings = "Кр.Субботы",
            //    NumberOfTrain = "963",
            //    RouteName = "Лондон-Париж",
            //    ListOfStops = listOfStops
            //};
            //await _regulatoryScheduleDtoAccessLayer.AddNewRegSh(tempRegSh, "Ленинградский");

            return NotFound(); //View();
        }
    }
}