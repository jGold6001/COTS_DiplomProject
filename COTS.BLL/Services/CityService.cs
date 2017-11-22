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

namespace COTS.BLL.Services
{
    public class CityService : ICityService
    {
        IUnitOfWork UnitOfWork { get; set; }
        IMapper mapper;

        public CityService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<City, CityDTO>()));
        }

        public void AddOrUpdate(CityDTO city)
        {
            throw new NotImplementedException();
        }

        public void Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CityDTO> GetAll()
        {
            return mapper.Map<IEnumerable<City>, IEnumerable<CityDTO>>(UnitOfWork.Cities.GetAll());
        }

        public CityDTO GetOne(int? id)
        {
            return mapper.Map<City, CityDTO>(UnitOfWork.Cities.Get(id.Value));
        }
    }
}
