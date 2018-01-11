using AutoMapper;
using COTS.BLL.DTO;
using COTS.BLL.Interfaces;
using COTS.WEBAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace COTS.WEBAPI.Controllers.WebApi
{
    [RoutePrefix("api/seance")]
    public class SeanceController : ApiController
    {
        ISeanceService seanceService;
        IMapper mapper;

        public SeanceController()
        {

        }

        public SeanceController(ISeanceService seanceService)
        {
            this.seanceService = seanceService;
            mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<SeanceDTO, SeanceViewModel>()
                        .ForMember("DateSeance", opt => opt.MapFrom(src => src.DateAndTime.ToShortDateString()))
                        .ForMember("TimeBegin", opt => opt.MapFrom(src => src.DateAndTime.ToString("HH:mm")))
            ));
        }

        [Route("getall/{cinemaId}/{movieId}/{date:datetime}")]
        public IEnumerable<SeanceViewModel> GetAllByCinemaMovieAndDate(string cinemaId, long movieId, DateTime date)
        {
            var seances = mapper.Map<IEnumerable<SeanceDTO>, IEnumerable<SeanceViewModel>>(
                seanceService.FindAllByCinemaMovieAndDate(cinemaId, movieId, date)
                );
            return seances;
        }

    }
}
