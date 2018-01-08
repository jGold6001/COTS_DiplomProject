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
    [RoutePrefix("api/cinema")]
    public class CinemaController : ApiController
    {
        ICinemaService cinemaService;
        IMapper mapper;

        public CinemaController()
        {

        }

        public CinemaController(ICinemaService cinemaService)
        {
            this.cinemaService = cinemaService;
            mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<CinemaDTO, CinemaViewModel>()));
        }

        [Route("getallbycity/{cityId}")]
        public IEnumerable<CinemaViewModel> GetAllByCity(string cityId)
        {
            IEnumerable<CinemaDTO> cinemasDTOs = cinemaService.FindAllByCity(cityId);
            var cinemas = mapper.Map<IEnumerable<CinemaDTO>, List<CinemaViewModel>>(cinemasDTOs);
            return cinemas;
        }

        [Route("{id}")]
        public CinemaViewModel GetOne(string id)
        {
            return mapper.Map<CinemaDTO, CinemaViewModel>(cinemaService.GetOne(id));
        }
    }
}
