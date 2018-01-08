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
    [RoutePrefix("api/city")]
    public class CityController : ApiController
    {
        ICityService cityService;
        IMapper mapper;

        public CityController()
        {

        }

        public CityController(ICityService cityService)
        {
            this.cityService = cityService;
            mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<CityDTO, CityViewModel>()));
        }

        [Route("getall")]
        public IEnumerable<CityViewModel> GetAll()
        {
            IEnumerable<CityViewModel> cities = mapper.Map<IEnumerable<CityDTO>, List<CityViewModel>>(cityService.GetAll());
            return cities;
        }
    }
}
