using COTS.BLL.Managers;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using COTS.BLL.Interfaces;
using COTS.BLL.Services;
using COTS.DAL.Repositories;
using System.Linq;
using COTS.DAL.Interfaces;
using System.Diagnostics;
using COTS.BLL.Managers.SeanceManager;
using COTS.BLL.Constants;

namespace COTS.BLL.Managers.SeanceManager
{
    [TestClass()]
    public class AssignerTariffTest
    {
        AssignerTariff assigner;
        IUnitOfWork unitOfWork;
        ISeanceService seanceService;

        [TestInitialize]
        public void Init()
        {
            unitOfWork = new EFUnitOfWork("CotsContext");
            seanceService = new SeanceService(unitOfWork);
        }


        [TestMethod()]
        public void ByDate_isNowDay_Test()
        {
            var seanceDTO = seanceService.GetAll().FirstOrDefault();
            assigner = new AssignerTariff(seanceDTO);
            var dateWeek = assigner.ByDate();
            Trace.WriteLine(dateWeek);
        }

        public static DateTime GetWeekday(DateTime start, DayOfWeek day)
        {
            int daysToAdd = ((int)day - (int)start.DayOfWeek + 7) % 7;
            return start.AddDays(daysToAdd);
        }

        [TestMethod()]
        public void ByDate_isWorkingDay_Test()
        {
            var seanceDTO = seanceService.GetAll().FirstOrDefault();
            DateTime workday = GetWeekday(seanceDTO.DateAndTime, DayOfWeek.Thursday);
            seanceDTO.DateAndTime = workday;
            assigner = new AssignerTariff(seanceDTO);
            var dateWeek = assigner.ByDate();
            Assert.AreEqual(WeekDays.WORKDAY, dateWeek);
        }

        [TestMethod()]
        public void ByDate_isHolidayDay_Test()
        {
            var seanceDTO = seanceService.GetAll().FirstOrDefault();
            DateTime holiday = GetWeekday(seanceDTO.DateAndTime, DayOfWeek.Saturday);
            seanceDTO.DateAndTime = holiday;
            assigner = new AssignerTariff(seanceDTO);
            var dateWeek = assigner.ByDate();
            Assert.AreEqual(WeekDays.HOLIDAY, dateWeek);
        }

        [TestMethod()]
        public void ByTimeTest()
        {
            var seanceDTO = seanceService.GetAll().FirstOrDefault();
            var time = seanceDTO.DateAndTime.TimeOfDay;
            assigner = new AssignerTariff(seanceDTO);
            var timePeriod = assigner.ByTime();
            Trace.WriteLine($"seanceTime - {seanceDTO.DateAndTime.TimeOfDay}, time period - {timePeriod}");
        }

        [TestMethod()]
        public void ByTime_isDay_Test()
        {
            var seanceDTO = seanceService.GetAll().FirstOrDefault();
            seanceDTO.DateAndTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 12, 1,0);          
            assigner = new AssignerTariff(seanceDTO);
            var timePeriod = assigner.ByTime();
            Assert.AreEqual(TimePeriod.DAY, timePeriod);
        }

        [TestMethod()]
        public void ByTime_isEvening_Test()
        {
            var seanceDTO = seanceService.GetAll().FirstOrDefault();
            seanceDTO.DateAndTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 17, 1, 0);
            assigner = new AssignerTariff(seanceDTO);
            var timePeriod = assigner.ByTime();
            Assert.AreEqual(TimePeriod.EVENING, timePeriod);
        }
    }
}

