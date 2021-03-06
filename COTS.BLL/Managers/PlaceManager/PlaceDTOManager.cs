﻿using COTS.BLL.DTO;
using COTS.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COTS.BLL.Managers.PlaceManager
{
    public class PlaceDTOManager
    {
        public static PlaceDTO AssignIsBusyTo(PlaceDTO placeDTO, long seanceId, ITicketService ticketService)
        {
            var isContainInTicket = ticketService.IsPlaceInTicket(placeDTO, seanceId);
            if (isContainInTicket)
                placeDTO.IsBusy = true;
            else
                placeDTO.IsBusy = false;

            return placeDTO;          
        }
    }
}
