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

        public JsonResult FindByCity(string id)
        {
            IEnumerable<CinemaViewModel> cinemas = mapper.Map<IEnumerable<CinemaDTO>, List<CinemaViewModel>>(cinemaService.FindAllByCity(id));
            return Json(cinemas, JsonRequestBehavior.AllowGet);
        }
    }
}