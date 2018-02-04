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
    [RoutePrefix("api/sector")]
    public class SectorController : ApiController
    {
        ISectorService sectorService;
        MapperUnitOfWork mapperUnitOfWork;

        public SectorController(ISectorService sectorService)
        {
            this.sectorService = sectorService;
            mapperUnitOfWork = new MapperUnitOfWork();
        }

        public SectorController()
        {

        }

        [Route("getall/{enterpriseId}")]
        public IEnumerable<SectorViewModel> GetAllByEnterprise(string enterpriseId)
        {
            return mapperUnitOfWork.SectorViewModelMapper.MapToCollectionObjects(sectorService.FindAllByEnterprice(enterpriseId));
        }
    }
}
