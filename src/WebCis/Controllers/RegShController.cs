using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer;
using Domain.Abstract;
using Microsoft.AspNetCore.Mvc;


namespace WebCis.Controllers
{
    public class RegShController : Controller
    {
        #region fileld

        private readonly IDomainAcessLayer _domainAcessLayer;
        private readonly IMapper _mapper;

        #endregion





        #region ctor

        public RegShController(IDomainAcessLayer domainAcessLayer, IMapper mapper)
        {
            _domainAcessLayer = domainAcessLayer;
            _mapper = mapper;
        }

        #endregion





        public IActionResult Index()
        {
            return NotFound(); //View();
        }
    }
}