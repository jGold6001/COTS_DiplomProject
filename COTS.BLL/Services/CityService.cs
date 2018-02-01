using COTS.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COTS.DAL.Entities;
using COTS.DAL.Interfaces;
using AutoMapper;
using COTS.BLL.DTO;
using COTS.BLL.Managers.MapperManager;

namespace COTS.BLL.Services
{
    public class CityService : ICityService
    {
        IUnitOfWork UnitOfWork { get; set; }
        MapperUnitOfWork mapperUnitOfWork;

        public CityService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            mapperUnitOfWork = new MapperUnitOfWork();
        }

        public void AddOrUpdate(CityDTO city)
        {          
            throw new NotImplementedException();
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CityDTO> GetAll()
        {
            return mapperUnitOfWork.CityDTOMapper.MapToCollectionObjects(UnitOfWork.Cities.GetAll());
        }

        public CityDTO GetOne(string id)
        {
            return mapperUnitOfWork.CityDTOMapper.MapToObject(UnitOfWork.Cities.Get(id));
        }
    }
}