using COTS.BLL.DTO;
using COTS.BLL.Interfaces;
using COTS.BLL.Services;
using COTS.DAL.Entities;
using COTS.DAL.Interfaces;
using COTS.DAL.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COTS.BLL.Tests.Services
{
    [TestClass()]
    public class SectorServiceTest
    {
        ISectorService sectorService;
        ISeanceService seanceService;
        IUnitOfWork unitOfWork;

        [TestInitialize()]
        public void Init()
        {
            unitOfWork = new EFUnitOfWork("CotsContext");
            sectorService = new SectorService(unitOfWork);
            seanceService = new SeanceService(unitOfWork);
        }

        [TestMethod()]
        public void FindAllBySeanceTest()
        {
            var seanceDTO = this.GetSeance();
            var sectors = sectorService.FindAllBySeance(seanceDTO.Id);
            foreach (var item in sectors)
                Trace.WriteLine($"{item.Id} {item.Name}");
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
