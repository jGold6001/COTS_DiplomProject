using COTS.BLL.BusinessModels.Constants;
using COTS.BLL.DTO;
using COTS.BLL.Interfaces;
using COTS.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COTS.BLL.BusinessModels
{
    public class TariffManager
    {
        SeanceDTO seanceDTO;
        public TariffManager(SeanceDTO seanceDTO)
        {
            this.seanceDTO = seanceDTO;
        }

        public List<TariffDTO> AssignTariffs()
        {

            var dayWeek = ByDate();
            var timePeriod = ByTime();
            var typeD = ByTypeD();
            var sectors = GetSectors();

            List<Tariff> tariffs = new List<Tariff>();


            return null;
        }

        public string ByDate()
        {
            DateTime date = seanceDTO.DateAndTime.Date;
            switch (date.DayOfWeek)
            {
                case DayOfWeek.Sunday: return WeekDays.HOLIDAY;
                case DayOfWeek.Saturday: return WeekDays.HOLIDAY;
            }
            return WeekDays.WORKING;
        }

        public string ByTime()
        {
            var time = seanceDTO.DateAndTime.TimeOfDay;

            TimeSpan startTimeDay = new TimeSpan(9, 0, 0);
            TimeSpan startTimeEverning = new TimeSpan(17, 0, 0);

            if (time > startTimeDay && time < startTimeEverning)
                return TimePeriod.Day;
            else
                return TimePeriod.Evening;
        }

        public string ByTypeD()
        {
            return seanceDTO.TypeD;
        }

        public List<SectorDTO> GetSectors()
        {
            //var sectors = sectorService
            return null;
        }

    }
}
