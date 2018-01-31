﻿using COTS.BLL.BusinessModels;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using COTS.DAL.Interfaces;
using COTS.BLL.Interfaces;
using COTS.DAL.Repositories;
using COTS.BLL.Services;
using System.Linq;
using System.Diagnostics;
using COTS.BLL.DTO;
using COTS.BLL.BusinessModels.TariffDTOModel;

namespace COTS.BLL.BusinessModels.Tests
{
    [TestClass()]
    public class TariffManagerTest
    {
        IUnitOfWork unitOfWork;
        ISeanceService seanceService;
        ISectorService sectorService;
        ITariffService tariffService;

        [TestInitialize]
        public void Init()
        {
            unitOfWork = new EFUnitOfWork("CotsContext");
            seanceService = new SeanceService(unitOfWork);
            sectorService = new SectorService(unitOfWork);
            tariffService = new TariffService(unitOfWork);
        }

        [TestMethod()]
        public void AssignTariffsTest()
        {
            var seanceDTO = this.GetSeance();
            var tariffDTOs = TariffDTOManager.AssignTariffsTo(seanceDTO, sectorService, tariffService);
            
            foreach (var item in tariffDTOs)
                Trace.WriteLine($"tariffName - {item.Name} , tariffPrice  - {item.Price}");
        }

        public SeanceDTO GetSeance()
        {
            foreach (var item in seanceService.GetAll())
            {
                if (item.HallId == 1
                    && item.DateAndTime.Date == DateTime.Now.Date
                )
                {
                    return item;
                }

            }
            return seanceService.GetAll().FirstOrDefault();
        }
    }
}