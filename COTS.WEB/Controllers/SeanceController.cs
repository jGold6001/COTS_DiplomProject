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
    [RoutePrefix("seance")]
    public class SeanceController : Controller
    {
        ISeanceService seanceService;
        IMapper mapper;

        public SeanceController(ISeanceService seanceService)
        {
            this.seanceService = seanceService;
            mapper = new Mapper(new MapperConfiguration(
                cfg => cfg.CreateMap<SeanceDTO, SeanceViewModel>()
                    .ForMember("DateSeance", opt => opt.MapFrom(src => src.DateAndTime.Date))
                    .ForMember("TimeBegin", opt => opt.MapFrom(src => src.DateAndTime.ToString("HH:mm")))
                ));
        }

        [Route("{cinemaId}/{date:datetime}")]
        public ActionResult GetAllByCinemaAndDate(string cinemaId, DateTime date)
        {
            IEnumerable<SeanceDTO> seancesDTO = seanceService.FindByCinemaAndDate(cinemaId, date);
            var seances = mapper.Map<IEnumerable<SeanceDTO>, IEnumerable<SeanceViewModel>>(seancesDTO);
            return PartialView("GetAllByCinemaAndDate", seances);
        }
    }
}