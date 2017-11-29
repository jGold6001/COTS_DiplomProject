using COTS.BLL.Services;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using COTS.BLL.Interfaces;
using COTS.DAL.Interfaces;
using COTS.DAL.Repositories;
using COTS.BLL.DTO;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;

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
        public void FindByCinemaAndDateTest()
        {
            string cinemaId = "mpx_skymall";
            var ticks = DateTime.Now.Date.Ticks;
            IEnumerable<SeanceDTO> seancesDTO = seanceService.FindByCinemaAndDate(cinemaId, ticks);

            foreach (var item in seancesDTO)
                Trace.WriteLine($"CinemaId: {item.CinemaId} and date {item.DateAndTime}");
        }

        [TestMethod()]
        public void FindByMovieAndDateTest()
        {
            long movieId = unitOfWork.Movies.GetAll().Select(m => m.Id).FirstOrDefault();
            var ticks = DateTime.Now.Date.Ticks;
            IEnumerable<SeanceDTO> seancesDTO = seanceService.FindByMovieAndDate(movieId, ticks);

            foreach (var item in seancesDTO)
                Trace.WriteLine($"MovieId: {item.MovieId} and date {item.DateAndTime}");
        }

        [TestMethod()]
        public void DateTest()
        {
            DateTime date = DateTime.Now;
            Trace.WriteLine("date with time: "+date.Ticks);
            Trace.WriteLine("date only: " + DateTime.Now.Date.Ticks);
            Trace.WriteLine(date.ToString("HH:mm"));
        }
    }
}
