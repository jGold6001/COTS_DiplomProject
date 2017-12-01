﻿using AutoMapper;
using COTS.BLL.DTO;
using COTS.BLL.Interfaces;
using COTS.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace COTS.WEB.Controllers
{
    [RoutePrefix("cinema")]
    public class CinemaController : Controller
    {
        ICinemaService cinemaService;
        IMapper mapper;
        public CinemaController(ICinemaService cinemaService)
        {
            this.cinemaService = cinemaService;
            mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<CinemaDTO, CinemaViewModel>()));
        }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetAllByCityJson(string cityId)
        {
            IEnumerable<CinemaViewModel> cinemas = mapper.Map<IEnumerable<CinemaDTO>, List<CinemaViewModel>>(cinemaService.FindAllByCity(cityId));
            return Json(cinemas, JsonRequestBehavior.AllowGet);
        }

        
        [Route("cinemas_by_city_with_date/{cityId}/{date:datetime}")]
        public ActionResult GetAllWithSeancesByCity(string cityId, DateTime date)
        {
            ViewBag.Date = date.ToString("yyyy-MM-dd");
            IEnumerable<CinemaDTO> cinemasDTOs = cinemaService.FindAllByCity(cityId);
            var cinemas = mapper.Map<IEnumerable<CinemaDTO>, List<CinemaViewModel>>(cinemasDTOs);
            return PartialView("GetAllWithSeancesByCity", cinemas);
        }

        [Route("cinemasbycity/{cityId}")]
        public ActionResult GetAllByCity(string cityId)
        {
            IEnumerable<CinemaDTO> cinemasDTOs = cinemaService.FindAllByCity(cityId); 
            var cinemas = mapper.Map<IEnumerable<CinemaDTO>, List<CinemaViewModel>>(cinemasDTOs);
            return PartialView("GetAllByCity", cinemas);
        }
    }
}