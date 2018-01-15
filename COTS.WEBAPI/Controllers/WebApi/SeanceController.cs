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
        IMovieService movieService;
        ICinemaService cinemaService;

        IMapper mapperSeance,
                mapperSeanceReverse,
                mapperMovie,
                mapperCinema;

        public SeanceController()
        {

        }

        public SeanceController(ISeanceService seanceService, IMovieService movieService, ICinemaService cinemaService)
        {
            this.seanceService = seanceService;
            this.movieService = movieService;
            this.cinemaService = cinemaService;

            mapperMovie = new Mapper(new MapperConfiguration(cnf => cnf.CreateMap<MovieDTO, MovieViewModel>()));
            mapperCinema = new Mapper(new MapperConfiguration(cnf => cnf.CreateMap<CinemaDTO, CinemaViewModel>()));
            mapperSeance = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<SeanceDTO, SeanceViewModel>()
                        .ForMember("DateSeance", opt => opt.MapFrom(src => src.DateAndTime.ToShortDateString()))
                        .ForMember("TimeBegin", opt => opt.MapFrom(src => src.DateAndTime.ToString("HH:mm")))
                        .ForMember("CinemaViewModel", opt => opt.MapFrom(src =>
                            mapperCinema.Map<CinemaDTO, CinemaViewModel>(cinemaService.GetOne(src.CinemaId)))
                        )
                        .ForMember("MovieViewModel", opt => opt.MapFrom(src =>
                            mapperMovie.Map<MovieDTO, MovieViewModel>(movieService.GetOne(src.MovieId)))
                        )
            ));
        }

        [Route("getall/{cinemaId}/{movieId}/{date:datetime}")]
        public IEnumerable<SeanceViewModel> GetAllByCinemaMovieAndDate(string cinemaId, long movieId, DateTime date)
        {  
            var seances = mapperSeance.Map<IEnumerable<SeanceDTO>, IEnumerable<SeanceViewModel>>(
                seanceService.FindAllByCinemaMovieAndDate(cinemaId, movieId, date)
                );

            var movie = mapperMovie.Map<MovieDTO, MovieViewModel>(movieService.GetOne(movieId));
            var cinema = mapperCinema.Map<CinemaDTO, CinemaViewModel>(cinemaService.GetOne(cinemaId));

            foreach (var item in seances)
            {
                item.MovieViewModel = movie;
                item.CinemaViewModel = cinema;
            }

            return seances;
        }

    }
}
