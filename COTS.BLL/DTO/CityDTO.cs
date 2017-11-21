﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COTS.BLL.DTO
{
    public class CityDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public CityDTO()
        {

        }

        public CityDTO(string name)
        {
            Name = name;
        }
    }
}
