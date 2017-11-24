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

namespace COTS.BLL.Services
{
    public class CinemaService : ICinemaService
    {
        IUnitOfWork UnitOfWork { get; set; }
        IMapper mapper;
        CinemaRepository cinemaRepo;

        public CinemaService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Cinema, CinemaDTO>()));
            cinemaRepo = UnitOfWork.Cinemas as CinemaRepository;
        }

        public void AddOrUpdate(CinemaDTO cinemaDTO)
        {
            throw new NotImplementedException();
        }

        public void Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CinemaDTO> FindAllByCity(string cityName)
        {
            return mapper.Map< IEnumerable<Cinema>, IEnumerable<CinemaDTO>>(cinemaRepo.FindAllByCity(cityName));
        }
    }
}
