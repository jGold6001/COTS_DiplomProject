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
    public class CityController : Controller
    {
        ICityService cityService;
        IMapper mapper;

        public CityController(ICityService cityService)
        {
            this.cityService = cityService;
            mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<CityDTO, CityViewModel>()));
        }

        public ActionResult Index()
        {
            IEnumerable<CityViewModel> cities = mapper.Map<IEnumerable<CityDTO>, List<CityViewModel>>(cityService.GetAll());
            return View(cities);
        }

        public JsonResult GetAll()
        {
            IEnumerable<CityViewModel> cities = mapper.Map<IEnumerable<CityDTO>, List<CityViewModel>>(cityService.GetAll());
            return Json(cities, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetOne(string id)
        {
            return View();
        }
    }
}