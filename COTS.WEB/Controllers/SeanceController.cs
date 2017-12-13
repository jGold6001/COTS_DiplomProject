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
        IMovieService movieService;
        ICinemaService cinemaService;

        IMapper mapper;

        public SeanceController(ISeanceService seanceService, IMovieService movieService, ICinemaService cinemaService)
        {
            this.seanceService = seanceService;
            this.movieService = movieService;
            this.cinemaService = cinemaService;

            IMapper movieMapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<MovieDTO, MoviePurchaseViewModel>()));
            IMapper cinemaMapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<CinemaDTO, CinemaPurchaseViewModel>()));

            mapper = new Mapper(new MapperConfiguration(
                cfg => cfg.CreateMap<SeanceDTO, SeanceViewModel>()
                    .ForMember("DateSeance", opt => opt.MapFrom(src => src.DateAndTime.ToShortDateString()))
                    .ForMember("TimeBegin", opt => opt.MapFrom(src => src.DateAndTime.ToString("HH:mm")))
                    .ForMember("Cinema", opt => opt.MapFrom(src =>cinemaMapper.Map<CinemaDTO, CinemaPurchaseViewModel>(cinemaService.GetOne(src.CinemaId))))
                    .ForMember("Movie", opt => opt.MapFrom(src => movieMapper.Map<MovieDTO, MoviePurchaseViewModel>(movieService.GetOne(src.MovieId))))
                ));
        }

        [Route("{cinemaId}/{movieId}/{date:datetime}")]
        public ActionResult GetAllByCinemaMovieAndDate(string cinemaId,long movieId, DateTime date)
        {
            IEnumerable<SeanceDTO> seancesDTO = seanceService.FindAllByCinemaMovieAndDate(cinemaId, movieId, date);
            var seances = mapper.Map<IEnumerable<SeanceDTO>, IEnumerable<SeanceViewModel>>(seancesDTO);
            return PartialView("GetAllByCinemaMovieAndDate", seances);
        }

        [Route("{seanceId}")]
        public ActionResult LoadHall(long seanceId)
        {
            var seanceDTO = seanceService.GetOne(seanceId);
            SeanceViewModel seanceViewModel = mapper.Map<SeanceDTO, SeanceViewModel>(seanceDTO);
            return PartialView(seanceViewModel);
        }

      
    }
}