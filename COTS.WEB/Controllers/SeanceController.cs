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
    public class SeanceController : Controller
    {
        ISeanceService seanceService;
        IMapper mapper;

        public SeanceController(ISeanceService seanceService)
        {
            this.seanceService = seanceService;
            mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<SeanceDTO, SeanceViewModel>()));
        }

        public ActionResult GetAllByCinema(long cinemaId)
        {
            IEnumerable<SeanceDTO> seanceDTO = seanceService.FindByCinema(cinemaId);
            var seances = mapper.Map<IEnumerable<SeanceDTO>, IEnumerable<SeanceViewModel>>(seanceDTO);
            return PartialView("GetAllByCinema", seances);
        }
    }
}