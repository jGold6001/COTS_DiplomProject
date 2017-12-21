﻿using COTS.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COTS.BLL.DTO
{
    public class TicketDTO
    {
        public string Id { get; set; }
        public long SeanceId { get; set; }
        public string Hall { get; set; }
        public int Row { get; set; }
        public int Place { get; set; }
        public string Tariff { get; set; }
        public decimal Price { get; set; }
        public string PurchaseId { get; set; }
        public int State { get; set; }
    }
}
