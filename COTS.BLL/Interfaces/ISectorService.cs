﻿using COTS.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COTS.BLL.Interfaces
{
    public interface ISectorService
    {
        SectorDTO GetOne(long? id);
        IEnumerable<SectorDTO> GetAll();
        IEnumerable<SectorDTO> FindAllBySeance(long? seanceId);
        IEnumerable<SectorDTO> FindAllByEnterprice(string enterpriseId);

    }
}
