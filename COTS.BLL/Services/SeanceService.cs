using COTS.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COTS.DAL.Entities;
using COTS.BLL.Infrastructure;
using AutoMapper;
using COTS.DAL.Interfaces;
using COTS.DAL.Repositories;
using COTS.BLL.DTO;

namespace COTS.BLL.Services
{
    public class SeanceService : ISeanceService
    {
        IUnitOfWork UnitOfWork { get; set; }
        IMapper mapper;
        SeanceRepository seanceRepo;

        public SeanceService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Seance, SeanceDTO>()));
            seanceRepo = UnitOfWork.Seances as SeanceRepository;
        }

        public void AddOrUpdate(Seance seance)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SeanceDTO> FindByCinema(long? cinemaId)
        {
            if (cinemaId == null)
                throw new ValidationException("'CinemaId' not set", "");

            IEnumerable<Seance> seances = seanceRepo.FindByCinema(cinemaId.Value);
            if (seances.Count() == 0)
                throw new ValidationException("Seances by cinema not found", "");

            IEnumerable<SeanceDTO> seancesDTO = mapper.Map<IEnumerable<Seance>, IEnumerable<SeanceDTO>>(seances);
            return seancesDTO;
        }

        public IEnumerable<SeanceDTO> FindByMovie(long? movieId)
        {
            if (movieId == null)
                throw new ValidationException("'MovieId' not set", "");

            IEnumerable<Seance> seances = seanceRepo.FindByMovie(movieId.Value);
            if(seances.Count() == 0)
                throw new ValidationException("Seances by movie not found", "");

            IEnumerable<SeanceDTO> seancesDTO = mapper.Map<IEnumerable<Seance>, IEnumerable<SeanceDTO>>(seances);
            return seancesDTO;
            
        }


        public IEnumerable<SeanceDTO> FindByDate(DateTime date)
        {
            throw new NotImplementedException();
        }

        public void Delete(long? id)
        {
            throw new NotImplementedException();
        }
    }
}
