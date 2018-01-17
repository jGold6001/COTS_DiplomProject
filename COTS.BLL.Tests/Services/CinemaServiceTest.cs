using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using COTS.BLL.Interfaces;
using COTS.DAL.Interfaces;
using COTS.DAL.Repositories;
using COTS.BLL.Services;
using System.Diagnostics;

namespace COTS.BLL.Services.Tests
{
    [TestClass()]
    public class CinemaServiceTest
    {
        ICinemaService cinemaService;
        IUnitOfWork unitOfWork;

        [TestInitialize()]
        public void Init()
        {
            unitOfWork = new EFUnitOfWork("CotsContext");
            cinemaService = new CinemaService(unitOfWork);
        }

        [TestMethod()]
        public void GetOneCinemaTest()
        {
            var cinema = cinemaService.GetOne("florence");
            Trace.WriteLine($"name - {cinema.Name}");
        }

        [TestMethod()]
        public void FindAllCinemasByCityTest()
        {
            var cinemas = cinemaService.FindAllByCity("kiev");
            foreach (var item in cinemas)
            {
                Trace.WriteLine($"name - {item.Name}");
            }
        }
    }
}
