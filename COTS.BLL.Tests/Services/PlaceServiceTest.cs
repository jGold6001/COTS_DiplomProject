using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using COTS.BLL.Interfaces;
using COTS.DAL.Interfaces;
using COTS.DAL.Repositories;
using COTS.BLL.Services;
using System.Collections.Generic;
using COTS.BLL.DTO;
using System.Diagnostics;
using System.Linq;

namespace COTS.BLL.Tests.Services
{
    [TestClass]
    public class PlaceServiceTest
    {
        IPlaceService placeService;
        ISeanceService seanceService;
        IUnitOfWork unitOfWork;

        [TestInitialize()]
        public void Init()
        {
            unitOfWork = new EFUnitOfWork("CotsContext");
            placeService = new PlaceService(unitOfWork);
            seanceService = new SeanceService(unitOfWork);
        }

        [TestMethod]
        public void GetAllByCityCinemaHallAndSeance_isBusyPLacesPresent_Test()
        {
            long seanceId = this.GetSeance().Id;
            List<PlaceDTO> places = placeService.GetAllByCityCinemaHallAndSeance("kiev", "florence", "Синий", seanceId) as List<PlaceDTO>;
            foreach (var item in places)
                Trace.WriteLine($"Place id: {item.Id} - row: {item.Row} - num: {item.Number} - isBusy - {item.IsBusy}");

        }

        [TestMethod]
        public void GetAllByHallAndSeance_isBusyPLacesPresent_Test()
        {
            long seanceId = this.GetSeance().Id;
            List<PlaceDTO> places = placeService.GetAllBySeanceAndHall(3, seanceId) as List<PlaceDTO>;
            Trace.WriteLine(places.Count());
            foreach (var item in places)
                Trace.WriteLine($"Place id: {item.Id} - row: {item.Row} - num: {item.Number} - isBusy - {item.IsBusy}");

        }

        [TestMethod]
        public void GetAllByCityCinemaHallAndSeance_isAllPlacesFree_Test()
        {
            List<PlaceDTO> places = placeService.GetAllByCityCinemaHallAndSeance("kiev", "florence", "Синий", 112123123213) as List<PlaceDTO>;
            foreach (var item in places)
                Trace.WriteLine($"Place id: {item.Id} - row: {item.Row} - num: {item.Number} - isBusy - {item.IsBusy}");

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
