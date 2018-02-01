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
using COTS.BLL.Utils;
using COTS.BLL.Managers.MapperManager;

namespace COTS.BLL.Services
{
    public class CinemaService : ICinemaService
    {
        IUnitOfWork UnitOfWork { get; set; }
        MapperUnitOfWork mapperUnitOfWork;

        public CinemaService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            mapperUnitOfWork = new MapperUnitOfWork();
        }

        public void AddOrUpdate(CinemaDTO cinemaDTO)
        {
            throw new NotImplementedException();
        }

        public CinemaDTO GetOne(string id)
        {
            if (id == null)
                throw new ValidationException("Cinema 'Id' not set", "");

            var cinema = UnitOfWork.Cinemas.Get(id);
            if(cinema == null)
                throw new ValidationException("Cinema not found", "");


            return mapperUnitOfWork.CinemaDTOMapper.MapToObject(cinema);
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CinemaDTO> FindAllByCity(string cityId)
        {
            if (cityId == null)
                throw new ValidationException("City 'Id' not set", "");

            IEnumerable<CinemaDTO> cinemas = mapperUnitOfWork.CinemaDTOMapper.MapToCollectionObjects(UnitOfWork.Cinemas.FindBy(c => c.CityId == cityId));
            if(cinemas.Count() == 0)
                throw new ValidationException("Cinemas by city not found", "");

            return cinemas;
        }

    }
}
