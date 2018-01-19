using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using COTS.BLL.DTO;
using COTS.WEBAPI.Models;

namespace COTS.WEBAPI.Utils.MapperManager.ViewModelMappers
{
    public class ClientDetailsViewModelMapper : GeneralMapper<PurchaseClientDetailsDTO, ClientDetailsViewModel>
    {
        public ClientDetailsViewModelMapper()
        {
            Mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<PurchaseClientDetailsDTO, ClientDetailsViewModel>()));
        }

        public override IEnumerable<ClientDetailsViewModel> MapToCollectionObjects(IEnumerable<PurchaseClientDetailsDTO> collectValues)
        {
            return Mapper.Map<IEnumerable<PurchaseClientDetailsDTO>, IEnumerable<ClientDetailsViewModel>>(collectValues);
        }

        public override ClientDetailsViewModel MapToObject(PurchaseClientDetailsDTO value)
        {
            return Mapper.Map<PurchaseClientDetailsDTO, ClientDetailsViewModel>(value);
        }
    }
}