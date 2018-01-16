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

        IMovieService movieService;
        ICinemaService cinemaService;

        public SeanceService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Seance, SeanceDTO>()));
            seanceRepo = UnitOfWork.Seances as SeanceRepository;

            movieService = new MovieService(unitOfWork);
            cinemaService = new CinemaService(unitOfWork);
        }

        public void AddOrUpdate(SeanceDTO seance)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SeanceDTO> FindByCinemaAndDate(string cinemaId, DateTime date)
        {
            throw new NotImplementedException();
        }


        public IEnumerable<SeanceDTO> FindByMovieAndDate(long? movieId, DateTime date)
        {
            throw new NotImplementedException();
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
            IEnumerable<SeanceDTO> seancesDTO = AttachObjetcsToDTOList(seances);          
            return seancesDTO;

        }

        public void Delete(long? id)
        {
            throw new NotImplementedException();
        }

        public SeanceDTO GetOne(long? id)
        {
            if (id == null)
                throw new ValidationException("'Id' not set", "");

            var seance = seanceRepo.Get(id.Value);

            if(seance == null)
                throw new ValidationException("seance not found", "");


            var seanceDTO = AttachObjetcsToDTO(seance);
            return seanceDTO;
        }

        public IEnumerable<SeanceDTO> GetAll()
        {
            var seances = seanceRepo.GetAll();
            IEnumerable<SeanceDTO> seancesDTO = AttachObjetcsToDTOList(seances);
            return seancesDTO;
        }


        private List<SeanceDTO> AttachObjetcsToDTOList(IEnumerable<Seance> seances)
        {
            var movieId = seances.FirstOrDefault().MovieId;
            var cinemaId = seances.FirstOrDefault().CinemaId;
            var movieDTO = movieService.GetOne(movieId);
            var cinemaDTO = cinemaService.GetOne(cinemaId);

            List<SeanceDTO> seancesDTO = mapper.Map<IEnumerable<Seance>, List<SeanceDTO>>(seances);

            foreach (var item in seancesDTO)
            {
                item.MovieDTO = movieDTO;
                item.CinemaDTO = cinemaDTO;
            }               
            return seancesDTO;
        }


        private SeanceDTO AttachObjetcsToDTO(Seance seance)
        {
            var movieDTO = movieService.GetOne(seance.MovieId);
            var cinemaDTO = cinemaService.GetOne(seance.CinemaId);

            SeanceDTO seanceDTO = mapper.Map<Seance, SeanceDTO>(seance);
            seanceDTO.MovieDTO = movieDTO;
            seanceDTO.CinemaDTO = cinemaDTO;
            
            return seanceDTO;
        }


    }
}
