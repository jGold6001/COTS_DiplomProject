﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COTS.BLL.DTO
{
    public class PlaceDTO
    {
        public long Id { get; set; }
        public int Row { get; set; }
        public int Number { get; set; }
        public bool IsBusy { get; set; }
        public long? HallId { get; set; }
        public long? SectorId { get; set; }
    }
}
