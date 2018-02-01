using COTS.BLL.Constants;
using COTS.BLL.DTO;
using COTS.BLL.Interfaces;
using COTS.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COTS.BLL.Managers.SeanceManager

{
    public class SeanceManager
    {     
        public static List<TariffDTO> AssignTariffsTo(SeanceDTO seanceDTO, ISectorService sectorService, ITariffService tariffService)
        {
            AssignerTariff assigner = new AssignerTariff(seanceDTO);

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
  
}
