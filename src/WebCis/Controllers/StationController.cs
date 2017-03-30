using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Abstract;
using Microsoft.AspNetCore.Mvc;


namespace WebCis.Controllers
{
    public class StationController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;



        public StationController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }




        public IActionResult Index()
        {



            return View();
        }
    }
}