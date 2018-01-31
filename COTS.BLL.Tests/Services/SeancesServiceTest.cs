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
        public void FindAllSeancesByCinemaAndDateTest()
        {
            string cinemaId = "mpx_skymall";
            long movieId = unitOfWork.Movies.GetAll().Select(m => m.Id).FirstOrDefault();
            IEnumerable<SeanceDTO> seancesDTO = seanceService.FindAllByCinemaMovieAndDate(cinemaId, movieId, DateTime.Now.Date);

            foreach (var item in seancesDTO)
                Trace.WriteLine($"IDSeance: {item.Id}, Cinema: {item.HallDTO.CinemaId}, Movie: {item.MovieDTO.Name} and date {item.DateAndTime}");
        }

        [TestMethod()]
        public void GetAllSeancesTest()
        {
            var seancesDTO = seanceService.GetAll();
            foreach (var item in seancesDTO)
                Trace.WriteLine($"IDSeance: {item.Id}, Cinema: {item.HallDTO.CinemaId}, Movie: {item.MovieDTO.Name} and date {item.DateAndTime}");

        }

        [TestMethod()]
        public void GetOneSeanceTest()
        {
            var seanceId = this.GetSeance().Id;
            var seanceDTO = seanceService.GetOne(seanceId);
            Trace.WriteLine($"IDSeance: {seanceDTO.Id}, Cinema: {seanceDTO.HallDTO.CinemaId}, Movie: {seanceDTO.MovieDTO.Name} and date {seanceDTO.DateAndTime}");
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
