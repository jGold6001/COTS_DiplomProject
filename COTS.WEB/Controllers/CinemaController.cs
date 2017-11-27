using AutoMapper;
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

        //public JsonResult FindByCity(string cityId)
        //{
        //    IEnumerable<CinemaViewModel> cinemas = mapper.Map<IEnumerable<CinemaDTO>, List<CinemaViewModel>>(cinemaService.FindAllByCity(cityId));
        //    return Json(cinemas, JsonRequestBehavior.AllowGet);
        //}

        public ActionResult GetAllByCity(string cityId)
        {
            IEnumerable<CinemaDTO> cinemasDTOs = cinemaService.FindAllByCity(cityId); 
            var cinemas = mapper.Map<IEnumerable<CinemaDTO>, List<CinemaViewModel>>(cinemasDTOs);
            return PartialView("GetAllByCity", cinemas);
        }
    }
}