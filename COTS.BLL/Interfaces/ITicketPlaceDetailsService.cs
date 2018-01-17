﻿using COTS.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COTS.BLL.Interfaces
{
    public interface ITicketPlaceDetailsService
    {
        void AddOrUpdate(TicketPlaceDetailsDTO ticketPlaceDetailsDTO);
        TicketPlaceDetailsDTO GetOne(string id);
        IEnumerable<TicketPlaceDetailsDTO> GetAll();
        void Delete(string id);
    }
}
