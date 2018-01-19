using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using COTS.BLL.DTO;
using COTS.WEBAPI.Models;
using COTS.WEBAPI.Utils.MapperManager;

namespace COTS.WEBAPI.Utils.MapperManager.DTOMappers
{
    public class PurchaseClientDetailsDTOMapper : GeneralMapper<ClientDetailsViewModel, PurchaseClientDetailsDTO>
    {
        public PurchaseClientDetailsDTOMapper()
        {
            Mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<ClientDetailsViewModel, PurchaseClientDetailsDTO>()));
        }

        public override IEnumerable<PurchaseClientDetailsDTO> MapToCollectionObjects(IEnumerable<ClientDetailsViewModel> collectValues)
        {
            return Mapper.Map<IEnumerable<ClientDetailsViewModel>, IEnumerable<PurchaseClientDetailsDTO>>(collectValues);
        }

        public override PurchaseClientDetailsDTO MapToObject(ClientDetailsViewModel value)
        {
            return Mapper.Map<ClientDetailsViewModel, PurchaseClientDetailsDTO>(value);
        }
    }
}