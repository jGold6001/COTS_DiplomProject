using COTS.BLL.BusinessModels;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using COTS.DAL.Interfaces;
using COTS.BLL.Interfaces;
using COTS.DAL.Repositories;
using COTS.BLL.Services;
using System.Linq;

namespace COTS.BLL.BusinessModels.Tests
{
    [TestClass()]
    public class TariffManagerTest
    {
        Assigner assigner;
        IUnitOfWork unitOfWork;
        ISeanceService seanceService;
        ISectorService sectorService;

        [TestInitialize]
        public void Init()
        {
            unitOfWork = new EFUnitOfWork("CotsContext");
            seanceService = new SeanceService(unitOfWork);
            sectorService = new SectorService(unitOfWork);
        }

        [TestMethod()]
        public void AssignTariffsTest()
        {           
            var seanceDTO = seanceService.GetAll().FirstOrDefault();
            var sectors = sectorService.FindAllBySeance(seanceDTO.Id);
            var tariffDTOs = TariffManager.AssignTariffsTo(seanceDTO, sectors);


        }
    }
}