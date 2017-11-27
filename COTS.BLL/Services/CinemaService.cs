using COTS.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COTS.DAL.Entities;
using AutoMapper;
using COTS.DAL.Interfaces;
using COTS.BLL.DTO;
using COTS.DAL.Repositories;
using COTS.BLL.Infrastructure;

namespace COTS.BLL.Services
{
    public class CinemaService : ICinemaService
    {
        IUnitOfWork UnitOfWork { get; set; }
        IMapper mapper;

        public CinemaService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Cinema, CinemaDTO>()));          
        }

        public void AddOrUpdate(CinemaDTO cinemaDTO)
        {
            throw new NotImplementedException();
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CinemaDTO> FindAllByCity(string cityId)
        {
            if (cityId == null)
                throw new ValidationException("City 'Id' not set", "");

            IEnumerable<CinemaDTO> cinemas = mapper.Map<IEnumerable<Cinema>, IEnumerable<CinemaDTO>>(UnitOfWork.Cinemas.FindBy(c => c.CityId == cityId));
            if(cinemas.Count() == 0)
                throw new ValidationException("Cinemas by city not found", "");

            return cinemas;
        }
    }
}
