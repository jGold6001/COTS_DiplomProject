using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COTS.BLL.DTO;
using COTS.DAL.Interfaces;
using AutoMapper;
using COTS.BLL.Utils;
using COTS.DAL.Entities;
using COTS.BLL.Utils.MapperManager;
using COTS.BLL.Interfaces;

namespace COTS.BLL.Services
{
    public class TariffService : ITariffService
    {
        IUnitOfWork UnitOfWork { get; set; }
        MapperUnitOfWork mapperUnitOfWork;

        public TariffService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            mapperUnitOfWork = new MapperUnitOfWork();
        }

        public void AddOrUpdate(TariffDTO cinemaDTO)
        {
            throw new NotImplementedException();
        }

        public void Delete(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TariffDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public TariffDTO GetOne(long id)
        {
            return mapperUnitOfWork.TariffDTOMapper.MapToObject(UnitOfWork.Tariffs.Get(id));
        }

        public TariffDTO GetOneByWeekDayTimePeriodTechnologyAndSector(string weekDay, string timePeriod, string technologyId, long sectorId)
        {
            var tariff = UnitOfWork.Tariffs.FindBy(t => t.WeekDay == weekDay && t.TimePeriod == timePeriod && t.TechnologyId == technologyId && t.SectorId == sectorId).FirstOrDefault();
            return mapperUnitOfWork.TariffDTOMapper.MapToObject(tariff);
        }
    }
}
