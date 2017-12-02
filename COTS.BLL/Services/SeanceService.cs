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

        public void AddOrUpdate(SeanceDTO seance)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SeanceDTO> FindByCinemaAndDate(string cinemaId, DateTime date)
        {
            if (cinemaId == null)
                throw new ValidationException("'CinemaId' not set", "");

            if (date == null)
                throw new ValidationException("'date' not set", "");


            IEnumerable<Seance> seances = seanceRepo.FindAllByCinemaAndDate(cinemaId, date);
            if (seances.Count() == 0)
                throw new ValidationException("Seances by cinema not found", "");

            IEnumerable<SeanceDTO> seancesDTO = mapper.Map<IEnumerable<Seance>, IEnumerable<SeanceDTO>>(seances);
            return seancesDTO;
        }

        public IEnumerable<SeanceDTO> FindByMovieAndDate(long? movieId, DateTime date)
        {
            if (movieId == null)
                throw new ValidationException("'MovieId' not set", "");

            if (date == null)
                throw new ValidationException("'date' not set", "");

            IEnumerable<Seance> seances = seanceRepo.FindAllByMovieAndDate(movieId.Value, date);
            if (seances.Count() == 0)
                throw new ValidationException("Seances by movie not found", "");

            IEnumerable<SeanceDTO> seancesDTO = mapper.Map<IEnumerable<Seance>, IEnumerable<SeanceDTO>>(seances);
            return seancesDTO;
            
        }

        public IEnumerable<SeanceDTO> FindByDate(DateTime date)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SeanceDTO> FindAllByCinemaMovieAndDate(string cinemaId, long? movieId, DateTime date)
        {
            if (cinemaId == null)
                throw new ValidationException("'CinemaId' not set", "");

            if (movieId == null)
                throw new ValidationException("'MovieId' not set", "");

            if (date == null)
                throw new ValidationException("'date' not set", "");

            IEnumerable<Seance> seances = seanceRepo.FindAllByCinemaMovieAndDate(cinemaId, movieId.Value, date);
            if (seances.Count() == 0)
                throw new ValidationException("Seances by movie not found", "");

            IEnumerable<SeanceDTO> seancesDTO = mapper.Map<IEnumerable<Seance>, IEnumerable<SeanceDTO>>(seances);
            return seancesDTO;

        }

        public void Delete(long? id)
        {
            throw new NotImplementedException();
        }
    }
}
