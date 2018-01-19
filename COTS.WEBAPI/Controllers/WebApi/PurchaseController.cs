using COTS.BLL.Interfaces;
using COTS.WEBAPI.Models;
using COTS.WEBAPI.Utils.MapperManager;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace COTS.WEBAPI.Controllers.WebApi
{
    [RoutePrefix("api/purchase")]
    public class PurchaseController : ApiController
    {
        IPurchaseService purchaseService;
        MapperUnitOfWork mapperUnitOfWork;

        public PurchaseController()
        {

        }

        public PurchaseController(IPurchaseService purchaseService)
        {
            this.purchaseService = purchaseService;
            mapperUnitOfWork = new MapperUnitOfWork();
        }

        [Route("all")]
        public IEnumerable<PurchaseViewModel> GetAll()
        {
            return mapperUnitOfWork.PurchaseViewModelMapper.MapToCollectionObjects(purchaseService.GetAll());
        }

        [HttpPost]
        [Route("save_in_db")]
        public void SaveInDb(PurchaseViewModel purchaseViewModel)
        {
            var purchaseDTO = mapperUnitOfWork.PurchaseDTOMapper.MapToObject(purchaseViewModel);
            purchaseService.AddOrUpdate(purchaseDTO);
        }     

        [Route("{Id}")]
        public PurchaseViewModel GetPurchase(string id)
        {
            return mapperUnitOfWork.PurchaseViewModelMapper.MapToObject(purchaseService.GetOne(id));
        }
    }
}
