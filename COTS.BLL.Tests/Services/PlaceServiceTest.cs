using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using COTS.BLL.Interfaces;
using COTS.DAL.Interfaces;
using COTS.DAL.Repositories;
using COTS.BLL.Services;
using System.Collections.Generic;
using COTS.BLL.DTO;
using System.Diagnostics;

namespace COTS.BLL.Tests.Services
{
    [TestClass]
    public class PlaceServiceTest
    {
        IPlaceService placeService;
        IUnitOfWork unitOfWork;

        [TestInitialize()]
        public void Init()
        {
            unitOfWork = new EFUnitOfWork("CotsContext");
            placeService = new PlaceService(unitOfWork);
        }

        [TestMethod]
        public void GetAllByCityCinemaAndHallTest()
        {            
            List<PlaceDTO> places = placeService.GetAllByCityCinemaAndHall("kiev", "florence", "Синий") as List<PlaceDTO>;
            foreach (var item in places)
                Trace.WriteLine($"Place id: {item.Id} - row: {item.Row} - num: {item.Number}");

        }

       
    }
}
