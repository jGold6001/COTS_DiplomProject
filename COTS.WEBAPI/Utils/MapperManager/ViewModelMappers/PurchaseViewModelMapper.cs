﻿using AutoMapper;
using COTS.BLL.DTO;
using COTS.WEBAPI.Models;
using COTS.WEBAPI.Utils.MapperManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace COTS.WEBAPI.Utils.MapperManager.ViewModelMappers
{
    public class PurchaseViewModelMapper : GeneralMapper<PurchaseDTO, PurchaseViewModel>
    {
        public PurchaseViewModelMapper(TicketViewModelMapper ticketViewModelMapper)
        {
            Mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<PurchaseDTO, PurchaseViewModel>()
                .ForMember("CustomerViewModel", opt => opt.MapFrom(src => src.CustomerDTO))
                .ForMember("TicketViewModels", opt => opt.MapFrom(src => ticketViewModelMapper.MapToCollectionObjects(src.TicketsDTOs)))
            ));
        }

        public override IEnumerable<PurchaseViewModel> MapToCollectionObjects(IEnumerable<PurchaseDTO> collectValues)
        {
            return Mapper.Map<IEnumerable<PurchaseDTO>, IEnumerable<PurchaseViewModel>>(collectValues);
        }

        public override PurchaseViewModel MapToObject(PurchaseDTO value)
        {
            return Mapper.Map<PurchaseDTO, PurchaseViewModel>(value);
        }
    }
}