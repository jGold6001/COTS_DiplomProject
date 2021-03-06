﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COTS.BLL.DTO
{
    public class SeanceDTO
    {
        public long Id { get; set; }
        public DateTime DateAndTime { get; set; }
        public string TechnologyId { get; set; }
        public TechnologyDTO TechnologyDTO { get; set; }
        public long? HallId { get; set; }
        public HallDTO HallDTO { get; set; }
        public MovieDTO MovieDTO { get; set; }  
        public long? MovieId { get; set; }
        public IEnumerable<TariffDTO> TariffDTOs { get; set; }
    }
}
