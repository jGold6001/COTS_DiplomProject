using AutoMapper;
using COTS.BLL.DTO;
using COTS.BLL.Interfaces;
using COTS.WEBAPI.Models;
using COTS.WEBAPI.Utils.MapperManager;
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

        MapperUnitOfWork mapperUnitOfWork;

        public MovieController()
        {

        }

        public MovieController(IMovieService movieService)
        {
            this.movieService = movieService;
            mapperUnitOfWork = new MapperUnitOfWork();         
        }

        [Route("{id}")]
        public MovieFullViewModel GetOne(long id)
        {
            return mapperUnitOfWork.MovieFullViewModelMapper.MapToObject(movieService.GetOne(id));           
        }

        [Route("all")]
        public IEnumerable<MovieShortViewModel> GetAll()
        {
            return mapperUnitOfWork.MovieShortViewModelMapper.MapToCollectionObjects(movieService.GetAll());
          
        }

        [Route("premeries/{cityId}")]
        public IEnumerable<MovieShortViewModel> GetAllPremeriesByCity(string cityId)
        {
            return mapperUnitOfWork.MovieShortViewModelMapper.MapToCollectionObjects(movieService.FindAllPremeriesByCity(cityId));          
        }

        [Route("comingsoon/{cityId}")]
        public IEnumerable<MovieShortViewModel> GetAllCommingSoonByCity(string cityId)
        {
            return mapperUnitOfWork.MovieShortViewModelMapper.MapToCollectionObjects(movieService.FindAllComingSoonByCity(cityId));          
        }

        [Route("top10/{cityId}")]
        public IEnumerable<MovieShortViewModel> GetTop10ByCity(string cityId)
        {
            return mapperUnitOfWork.MovieShortViewModelMapper.MapToCollectionObjects(movieService.GetTop10ByRankOrderByCity(cityId));
        }

    }
}
