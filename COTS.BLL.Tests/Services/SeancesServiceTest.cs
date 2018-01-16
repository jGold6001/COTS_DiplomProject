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
                Trace.WriteLine($"IDSeance: {item.Id}, Cinema: {item.CinemaDTO.Name}, Movie: {item.MovieDTO.Name} and date {item.DateAndTime}");
        }
      
    }
}
