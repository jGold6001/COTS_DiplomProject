﻿using AutoMapper;
using COTS.BLL.DTO;
using COTS.WEBAPI.Models;
using COTS.WEBAPI.Utils.MapperManeger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace COTS.WEBAPI.Utils.MapperManager
{
    public class TicketViewModelMapper : GeneralMapper<TicketDTO, TicketViewModel>
    {
        public TicketViewModelMapper(SeanceViewModelMapper seanceViewModelMapper)
        {
            Mapper = new Mapper(new MapperConfiguration(cnf => cnf.CreateMap<TicketDTO, TicketViewModel>()
                .ForMember("SeanceViewModel", opt => opt.MapFrom(src => seanceViewModelMapper.MapToObject(src.SeanceDTO)))
                .ForMember("PlaceDetailsViewModel", opt => opt.MapFrom(src => src.TicketPlaceDetailsDTO))
           ));
        }


        public override IEnumerable<TicketViewModel> MapToCollectionObjects(IEnumerable<TicketDTO> collectValues)
        {
            return Mapper.Map<IEnumerable<TicketDTO>, IEnumerable<TicketViewModel>>(collectValues);
        }

        public override TicketViewModel MapToObject(TicketDTO value)
        {
            return Mapper.Map<TicketDTO, TicketViewModel>(value);
        }
    }
}