using COTS.BLL.BusinessModels.Constants;
using COTS.BLL.DTO;
using COTS.BLL.Interfaces;
using COTS.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COTS.BLL.BusinessModels.TariffDTOModel

{
    public class TariffDTOManager
    {     
        public static List<TariffDTO> AssignTariffsTo(SeanceDTO seanceDTO, ISectorService sectorService, ITariffService tariffService)
        {
            Assigner assigner = new Assigner(seanceDTO);

            var dayWeek = assigner.ByDate();
            var timePeriod = assigner.ByTime();
            var typeD = assigner.ByTypeD();
            var sectors = assigner.BySectors(sectorService);

            List<TariffDTO> tariffs = new List<TariffDTO>();
            foreach (var sector in sectors)
            {
                var tariffDTO = tariffService.GetOneByWeekDayTimePeriodTechnologyAndSector(dayWeek, timePeriod, typeD, sector.Id);
                tariffs.Add(tariffDTO);
            }
               
          
            return tariffs;
        }
    }

    public class Assigner
    {
        SeanceDTO seanceDTO;
        public Assigner(SeanceDTO seanceDTO)
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
