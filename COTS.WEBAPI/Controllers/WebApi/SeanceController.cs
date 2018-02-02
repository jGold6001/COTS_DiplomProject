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

namespace COTS.WEBAPI.Controllers.WebApi
{
    [RoutePrefix("api/seance")]
    public class SeanceController : ApiController
    {
        ISeanceService seanceService;

        MapperUnitOfWork mapperUnitOfWork;

        public SeanceController()
        {

        }

        public SeanceController(ISeanceService seanceService)
        {
            this.seanceService = seanceService;
            mapperUnitOfWork = new MapperUnitOfWork();        
        }

        [Route("getall/{cinemaId}/{movieId}/{date:datetime}")]
        public IEnumerable<SeanceViewModel> GetAllByCinemaMovieAndDate(string cinemaId, long movieId, DateTime date)
        {
            return mapperUnitOfWork.SeanceViewModelMapper.MapToCollectionObjects(seanceService.FindAllByCinemaMovieAndDate(cinemaId, movieId, date));          
        }

        [Route("{id}")]
        public SeanceViewModel GetOne(long id)
        {
            return mapperUnitOfWork.SeanceViewModelMapper.MapToObject(seanceService.GetOne(id));
        }

    }
}
