using COTS.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COTS.DAL.Entities;
using COTS.BLL.Utils;
using AutoMapper;
using COTS.DAL.Interfaces;
using COTS.DAL.Repositories;
using COTS.BLL.DTO;
using COTS.BLL.Utils.MapperManager;

namespace COTS.BLL.Services
{
    public class SeanceService : ISeanceService
    {
        IUnitOfWork UnitOfWork { get; set; }
        IMovieService movieService;
        IHallService hallService;

        SeanceRepository seanceRepo;
        MapperUnitOfWork mapperUnitOfWork;


        public SeanceService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            seanceRepo = UnitOfWork.Seances as SeanceRepository;

            movieService = new MovieService(unitOfWork);
            hallService = new HallService(unitOfWork);
            mapperUnitOfWork = new MapperUnitOfWork();
        }

        public void AddOrUpdate(SeanceDTO seance)
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
            IEnumerable<SeanceDTO> seancesDTOs = AttachObjetcsToDTOList(seances);          
            return seancesDTOs;

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

        public void Delete(long? id)
        {
            throw new NotImplementedException();
        }

        private IEnumerable<SeanceDTO> AttachObjetcsToDTOList(IEnumerable<Seance> seances)
        {
            
            IEnumerable<SeanceDTO> seancesDTO = mapperUnitOfWork.SeanceDTOMapper.MapToCollectionObjects(seances);

            foreach (var item in seancesDTO)
            {
                item.MovieDTO = movieService.GetOne(item.MovieId); ;
                item.HallDTO = hallService.GetOne(item.HallId);
            }   
            
            return seancesDTO;
        }

        private SeanceDTO AttachObjetcsToDTO(Seance seance)
        {
            SeanceDTO seanceDTO = mapperUnitOfWork.SeanceDTOMapper.MapToObject(seance);
            //seanceDTO.Tariffs = AssignTariffs(seanceDTO);
            seanceDTO.MovieDTO = movieService.GetOne(seanceDTO.MovieId);
            seanceDTO.HallDTO = hallService.GetOne(seanceDTO.HallId);
            return seanceDTO;
        }


    }
}
