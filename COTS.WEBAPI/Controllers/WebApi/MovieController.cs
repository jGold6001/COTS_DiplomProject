using AutoMapper;
using COTS.BLL.DTO;
using COTS.BLL.Interfaces;
using COTS.WEBAPI.Models;
using COTS.WEBAPI.Utils.MapperManeger;
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
            return mapperUnitOfWork.MovieViewModelMapper.MapToObject(movieService.GetOne(id));           
        }

        [Route("all")]
        public IEnumerable<MovieFullViewModel> GetAll()
        {
            return mapperUnitOfWork.MovieViewModelMapper.MapToCollectionObjects(movieService.GetAll());
          
        }

        [Route("premeries/{cityId}")]
        public IEnumerable<MovieFullViewModel> GetAllPremeriesByCity(string cityId)
        {
            return mapperUnitOfWork.MovieViewModelMapper.MapToCollectionObjects(movieService.FindAllPremeriesByCity(cityId));          
        }

        [Route("comingsoon/{cityId}")]
        public IEnumerable<MovieFullViewModel> GetAllCommingSoonByCity(string cityId)
        {
            return mapperUnitOfWork.MovieViewModelMapper.MapToCollectionObjects(movieService.FindAllComingSoonByCity(cityId));          
        }

        [Route("top10/{cityId}")]
        public IEnumerable<MovieFullViewModel> GetTop10ByCity(string cityId)
        {
            return mapperUnitOfWork.MovieViewModelMapper.MapToCollectionObjects(movieService.GetTop10ByRankOrderByCity(cityId));
        }

    }
}
