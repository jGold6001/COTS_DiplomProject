﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COTS.BLL.DTO
{
    public class HallDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string CinemaId { get; set; }
        public CinemaDTO CinemaDTO { get; set; }
    }
}
