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

namespace COTS.WEBAPI.Controllers
{   
    [RoutePrefix("api/movie")]
    public class MovieController : ApiController
    {
        IMovieService movieService;
        IMapper mapper;

        public MovieController()
        {

        }

        public MovieController(IMovieService movieService)
        {
            this.movieService = movieService;
            mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<MovieDTO, MovieViewModel>()
               .ForMember("DateIssue", opt => opt.MapFrom(src => src.DateIssue.ToShortDateString()))
            ));
        }

        [Route("{id}")]
        public MovieViewModel GetOne(long id)
        {
            return mapper.Map<MovieDTO, MovieViewModel>(movieService.GetOne(id));
        }

        [Route("all")]
        public IEnumerable<MovieViewModel> GetAll()
        {
            var movies = mapper.Map<IEnumerable<MovieDTO>, IEnumerable<MovieViewModel>>(movieService.GetAll());
            return movies;
        }

        [Route("premeries/{cityId}")]
        public IEnumerable<MovieViewModel> GetAllPremeriesByCity(string cityId)
        {
            IEnumerable<MovieDTO> moviesDTOs = movieService.FindAllPremeriesByCity(cityId);
            var movies = mapper.Map<IEnumerable<MovieDTO>, IEnumerable<MovieViewModel>>(moviesDTOs);
            return movies;
        }

        [Route("comingsoon/{cityId}")]
        public IEnumerable<MovieViewModel> GetAllCommingSoonByCity(string cityId)
        {          
            IEnumerable<MovieDTO> moviesDTOs = movieService.FindAllComingSoonByCity(cityId);
            var movies = mapper.Map<IEnumerable<MovieDTO>, IEnumerable<MovieViewModel>>(moviesDTOs);
            return movies;
        }

        [Route("top10/{cityId}")]
        public IEnumerable<MovieViewModel> GetTop10ByCity(string cityId)
        {
            IEnumerable<MovieDTO> moviesDTOs = movieService.GetTop10ByRankOrderByCity(cityId);
            var movies = mapper.Map<IEnumerable<MovieDTO>, IEnumerable<MovieViewModel>>(moviesDTOs);
            return movies;
        }

    }
}
