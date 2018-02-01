using COTS.BLL.Constants;
using COTS.BLL.DTO;
using COTS.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COTS.BLL.Managers.SeanceManager
{
    public class AssignerTariff
    {
        SeanceDTO seanceDTO;
        public AssignerTariff(SeanceDTO seanceDTO)
        {
            this.seanceDTO = seanceDTO;
        }

        public string ByDate()
        {
            DateTime date = seanceDTO.DateAndTime.Date;
            switch (date.DayOfWeek)
            {
                case DayOfWeek.Sunday: return WeekDays.HOLIDAY;
                case DayOfWeek.Saturday: return WeekDays.HOLIDAY;
            }
            return WeekDays.WORKDAY;
        }

        public string ByTime()
        {
            var time = seanceDTO.DateAndTime.TimeOfDay;

            TimeSpan startTimeDay = new TimeSpan(9, 0, 0);
            TimeSpan startTimeEverning = new TimeSpan(17, 0, 0);

            if (time > startTimeDay && time < startTimeEverning)
                return TimePeriod.DAY;
            else
                return TimePeriod.EVENING;
        }

        public string ByTypeD()
        {
            return seanceDTO.TechnologyId;
        }

        public IEnumerable<SectorDTO> BySectors(ISectorService sectorService)
        {
            return sectorService.FindAllBySeance(seanceDTO.Id);
        }

    }
}
