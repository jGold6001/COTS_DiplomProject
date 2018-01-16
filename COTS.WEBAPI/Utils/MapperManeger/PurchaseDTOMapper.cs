using AutoMapper;
using COTS.BLL.DTO;
using COTS.WEBAPI.Models;
using COTS.WEBAPI.Utils.MapperManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace COTS.WEBAPI.Utils.MapperManeger
{
    public class PurchaseDTOMapper : GeneralMapper<PurchaseViewModel, PurchaseDTO>
    {
        public PurchaseDTOMapper()
        {
            Mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<PurchaseViewModel, PurchaseDTO>()));
        }

        public override IEnumerable<PurchaseDTO> MapToCollectionObjects(IEnumerable<PurchaseViewModel> collectValues)
        {
           return Mapper.Map<IEnumerable<PurchaseViewModel>, IEnumerable<PurchaseDTO>>(collectValues);
        }

        public override PurchaseDTO MapToObject(PurchaseViewModel value)
        {
            return Mapper.Map<PurchaseViewModel, PurchaseDTO>(value);
        }
    }
}