using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using COTS.BLL.Interfaces;
using COTS.DAL.Interfaces;
using COTS.DAL.Repositories;
using COTS.BLL.Services;
using COTS.BLL.DTO;
using System.Linq;
using System.Diagnostics;

namespace COTS.BLL.Tests.Services
{
    [TestClass]
    public class TariffServiceTest
    {
        IUnitOfWork unitOfWork;
        ITariffService tariffService;
        ISectorService sectorService;
        ISeanceService seanceService;

        [TestInitialize()]
        public void Init()
        {
            unitOfWork = new EFUnitOfWork("CotsContext");
            tariffService = new TariffService(unitOfWork);
            sectorService = new SectorService(unitOfWork);
            seanceService = new SeanceService(unitOfWork);
        }

        [TestMethod]
        public void GetOneTariffByWeekDayTimePeriodTechnologyAndSectorTest()
        {
            var seanceDTO = this.GetSeance();
            var dayWeek = "workday";
            var timePeriod = "day";
            var typeD = "2d";
            var sectorId = sectorService.FindAllBySeance(seanceDTO.Id).FirstOrDefault().Id;

            var tariffDTO = tariffService.GetOneByWeekDayTimePeriodTechnologyAndSector(dayWeek, timePeriod, typeD, sectorId);
            Trace.WriteLine($"tariffName - {tariffDTO.Name} , tariffPrice  - {tariffDTO.Price}");
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
