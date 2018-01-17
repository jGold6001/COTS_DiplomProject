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
    [RoutePrefix("api/city")]
    public class CityController : ApiController
    {
        ICityService cityService;
        MapperUnitOfWork mapperUnitOfWork;

        public CityController()
        {

        }

        public CityController(ICityService cityService)
        {
            this.cityService = cityService;
            mapperUnitOfWork = new MapperUnitOfWork();
        }

        [Route("getall")]
        public IEnumerable<CityViewModel> GetAll()
        {
            return mapperUnitOfWork.CityViewModelMapper.MapToCollectionObjects(cityService.GetAll());           
        }
    }
}
