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
    [RoutePrefix("api/cinema")]
    public class CinemaController : ApiController
    {
        ICinemaService cinemaService;

        MapperUnitOfWork mapperUnitOfWork;

        public CinemaController()
        {

        }

        public CinemaController(ICinemaService cinemaService)
        {
            this.cinemaService = cinemaService;
            mapperUnitOfWork = new MapperUnitOfWork();          
        }

        [Route("getallbycity/{cityId}")]
        public IEnumerable<CinemaViewModel> GetAllByCity(string cityId)
        {
            return mapperUnitOfWork.CinemaViewModelMapper.MapToCollectionObjects(cinemaService.FindAllByCity(cityId));          
        }

        [Route("{id}")]
        public CinemaViewModel GetOne(string id)
        {
            return mapperUnitOfWork.CinemaViewModelMapper.MapToObject(cinemaService.GetOne(id));
        }
    }
}
