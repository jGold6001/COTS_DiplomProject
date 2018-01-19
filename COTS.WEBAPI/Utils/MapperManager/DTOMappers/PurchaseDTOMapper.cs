using AutoMapper;
using COTS.BLL.DTO;
using COTS.WEBAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace COTS.WEBAPI.Utils.MapperManager.DTOMappers
{
    public class PurchaseDTOMapper : GeneralMapper<PurchaseViewModel, PurchaseDTO>
    {
        public PurchaseDTOMapper(TicketDTOMapper ticketDTOMapper)
        {
            Mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<PurchaseViewModel, PurchaseDTO>()
                .ForMember(d => d.PurchaseClientDetailsDTO, opt => opt.MapFrom(src => src.ClientDetailsViewModel))
                .ForMember(d => d.TicketsDTOs, opt => opt.MapFrom(src => ticketDTOMapper.MapToCollectionObjects(src.TicketViewModels)))
            ));
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