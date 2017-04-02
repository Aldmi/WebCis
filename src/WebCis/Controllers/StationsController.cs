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
using WebCis.ViewModel;


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
            var stations = await _domainAcessLayer.GetAllStation("Ленинградский");
            if (stations != null)
            {
                IEnumerable<StationViewModel> railwayStationStationsVm = _mapper.Map<List<StationViewModel>>(stations);

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

            var stationVm= _mapper.Map<StationViewModel>(station);
            return View(stationVm);
        }



        // GET: Stations/Create
        public IActionResult Create()
        {
            return View();
        }


        // POST: Stations/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,EcpCode,Description")] StationViewModel stationViewModel)
        {
            if (ModelState.IsValid)
            {
              var stationDto= _mapper.Map<StationDto>(stationViewModel);
              await _domainAcessLayer.AddNewStation(stationDto, "Ленинградский");
              return RedirectToAction("Index");
            }
            return View(stationViewModel);
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

            var stationVm = _mapper.Map<StationViewModel>(station);
            return View(stationVm);
        }



        // POST: Stations/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,EcpCode,Description")] StationViewModel stationViewModel)
        {
            if (id != stationViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
              var stationDto = _mapper.Map<StationDto>(stationViewModel);
              var result= await _domainAcessLayer.EditStation(stationDto);
                
              return result ? RedirectToAction("Index") : null;    //TODO: null заменить на страницу с ошибками.
            }
            return View(stationViewModel);
        }


        // GET: Stations/Delete/5
        public async Task<IActionResult> Delete(int? id)
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
            if (station.Name == "НЕИЗВЕСТНО")
            {
                return NotFound();           //TODO: вернуть страницу с ошибкой, на которой написанно "станцию НЕИЗВЕСТНО удалить невозможно."
            }

            var stationVm = _mapper.Map<StationViewModel>(station);

            return View(stationVm);
        }



        //POST: Stations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stationDeleting = await _domainAcessLayer.GetStationById(id);
            if (stationDeleting == null)
            {
                return NotFound();
            }

           var result= await _domainAcessLayer.RemoveStationById(id);

           return result ? RedirectToAction("Index") : null;    //TODO: null заменить на страницу с ошибками.
        }

    }
}