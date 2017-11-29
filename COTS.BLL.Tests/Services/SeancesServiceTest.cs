using COTS.BLL.Services;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using COTS.BLL.Interfaces;
using COTS.DAL.Interfaces;
using COTS.DAL.Repositories;
using COTS.BLL.DTO;

namespace COTS.BLL.Services.Tests
{
    [TestClass()]
    public class SeancesServiceTest
    {
        ISeanceService seanceService;
        IUnitOfWork unitOfWork;

        [TestInitialize()]
        public void init()
        {
            unitOfWork = new EFUnitOfWork("CotsContext");
            seanceService = new SeanceService(unitOfWork);
        }

        [TestMethod()]
        public void FindByCinemaTest()
        {
            
            //IEquatable<SeanceDTO> seancesDTO = seanceService.FindByCinema();
        }
    }
}
