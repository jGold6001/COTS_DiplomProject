using COTS.BLL.Interfaces;
using COTS.WEBAPI.Utils.MapperManager;
using COTS.WEBAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace COTS.WEBAPI.Controllers.WebApi
{
    [RoutePrefix("api/place")]
    public class PlaceController : ApiController
    {
        IPlaceService placeService;
        MapperUnitOfWork mapperUnitOfWork;

        public PlaceController()
        {

        }

        public PlaceController(IPlaceService placeService)
        {
            this.placeService = placeService;
            mapperUnitOfWork = new MapperUnitOfWork();
        }

        [Route("getall/{cityId}/{cinemaId}/{hallName}/{seanceId}")]
        public IEnumerable<PlaceViewModel> GetByHall(string cityId, string cinemaId, string hallName, long seanceId)
        {           
            return mapperUnitOfWork.PlaceViewModelMapper.MapToCollectionObjects(placeService.GetAllByCityCinemaHallAndSeance(cityId, cinemaId, hallName, seanceId));
        }
    }
}
