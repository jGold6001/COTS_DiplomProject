using AutoMapper;
using COTS.BLL.DTO;
using COTS.BLL.Interfaces;
using COTS.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace COTS.WEB.Controllers.WebApi
{
    public class CityController : ApiController
    {
        ICityService cityService;
        IMapper mapper;

        public CityController(ICityService cityService)
        {
            this.cityService = cityService;
            mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<CityDTO, CityViewModel>()));
        }

        public CityController()
        {

        }
        public IEnumerable<CityViewModel> GetCities()
        {
            //return new List<CityViewModel>()
            //{
            //    new CityViewModel("h", "Harkov"),
            //    new CityViewModel("k", "Kiew")
            //};
            return mapper.Map<IEnumerable<CityDTO>, IEnumerable<CityViewModel>>(cityService.GetAll());
        }
    }
}
