﻿using AutoMapper;
using COTS.BLL.DTO;
using COTS.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COTS.BLL.Managers.MapperManager.DTOMappers
{
    public class PurchaseDTOMapper : GeneralMapper<Purchase, PurchaseDTO>
    {
        public PurchaseDTOMapper()
        {
            Mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Purchase, PurchaseDTO>()
                .ForMember(m => m.CustomerDTO, opt => opt.MapFrom(src => src.Сustomer))
            ));
        }

        public override IEnumerable<PurchaseDTO> MapToCollectionObjects(IEnumerable<Purchase> collectValues)
        {
           return Mapper.Map<IEnumerable<Purchase>, IEnumerable<PurchaseDTO>>(collectValues);
        }

        public override PurchaseDTO MapToObject(Purchase value)
        {
            return Mapper.Map<Purchase, PurchaseDTO>(value);
        }
    }
}
