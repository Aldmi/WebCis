using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer;
using Domain.Abstract;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebCis.Model;


namespace WebCis.Controllers
{
    public class StationsController : Controller
    {
        #region fileld

        private readonly IDomainAcessLayer _domainAcessLayer;
        private readonly IMapper _mapper;

        #endregion





        #region ctor

        public StationsController(IDomainAcessLayer domainAcessLayer, IMapper mapper)
        {
            _domainAcessLayer = domainAcessLayer;
            _mapper = mapper;
        }

        #endregion






        // GET: Stations
        public async Task<IActionResult> Index(string stationsNameFilter)
        {
            var stations = await _domainAcessLayer.GetAllStationByRailwayStationName("Ленинградский");
            if (stations != null)
            {
                IEnumerable<StationModel> railwayStationStationsVm = _mapper.Map<List<StationModel>>(stations);

                if (!string.IsNullOrEmpty(stationsNameFilter))
                {
                    railwayStationStationsVm = railwayStationStationsVm.Where(st => st.Name.Contains(stationsNameFilter));
                }

                return View(railwayStationStationsVm);
            }

            return NotFound();
        }



        // GET: Stations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var station = await _domainAcessLayer.GetStationById(id.Value);
            if (station == null)
            {
                return NotFound();
            }

           var stationModel= _mapper.Map<StationModel>(station);
            return View(stationModel);
        }



        // GET: Stations/Create
        public IActionResult Create()
        {
            return View();
        }


        // POST: Stations/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,EcpCode,Description")] StationModel stationModel)
        {
            if (ModelState.IsValid)
            {
              var stationDto= _mapper.Map<Station>(stationModel);
              await _domainAcessLayer.AddNewStation(stationDto, "Ленинградский");
              return RedirectToAction("Index");
            }
            return View(stationModel);
        }



        // GET: Stations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var station = await _domainAcessLayer.GetStationById(id.Value);
            if (station == null)
            {
                return NotFound();
            }

            var stationModel = _mapper.Map<StationModel>(station);
            return View(stationModel);
        }



        // POST: Stations/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,EcpCode,Description")] StationModel stationModel)
        {
            if (id != stationModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
              var stationDto = _mapper.Map<Station>(stationModel);
              var result= await _domainAcessLayer.EditStation(stationDto);
                
              return result ? RedirectToAction("Index") : null;    //TODO: null заменить на страницу с ошибками.
            }
            return View(stationModel);
        }


        // GET: Stations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var movie = await _context.Movie
            //    .SingleOrDefaultAsync(m => m.Id == id);
            //if (movie == null)
            //{
            //    return NotFound();
            //}

            return View();
        }



        // POST: Movies/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var movie = await _context.Movie.SingleOrDefaultAsync(m => m.Id == id);
        //    _context.Movie.Remove(movie);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction("Index");
        //}

    }
}