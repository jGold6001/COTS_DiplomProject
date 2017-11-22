using COTS.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COTS.BLL.DTO;
using COTS.DAL.Interfaces;
using AutoMapper;
using COTS.DAL.Entities;
using COTS.DAL.Repositories;
using COTS.BLL.Infrastructure;

namespace COTS.BLL.Services
{
    public class MovieService : IMovieService
    {
        IUnitOfWork UnitOfWork { get; set; }
        MovieRepository movieRepo;
        IMapper mapper;

        public MovieService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            movieRepo = unitOfWork.Movies as MovieRepository;
            mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Movie, MovieDTO>()));
        }

        public void AddOrUpdate(MovieDTO movieDTO)
        {
            throw new NotImplementedException();
        }
       
        public IEnumerable<MovieDTO> GetTop10()
        {
            return mapper.Map<IEnumerable<Movie>, IEnumerable<MovieDTO>>(movieRepo.GetTop10ByRankOrder());
        }

        public IEnumerable<MovieDTO> FindAllComingSoon()
        {            
            return mapper.Map<IEnumerable<Movie>, IEnumerable<MovieDTO>>(movieRepo.FindAllComingSoon());
        }

        public IEnumerable<MovieDTO> FindAllPremeries()
        {
            return mapper.Map<IEnumerable<Movie>, IEnumerable<MovieDTO>> (movieRepo.FindAllPremeries());
        }

        public IEnumerable<MovieDTO> GetAll()
        {
            return mapper.Map<IEnumerable<Movie>, IEnumerable<MovieDTO>>(movieRepo.GetAll());
        }

        public MovieDTO GetOne(int? id)
        {
            if (id == null)
                throw new ValidationException("Movie 'Id' not set", "");

            var movie = movieRepo.Get(id.Value);
            if (movie == null)
                throw new ValidationException("Movie not found","");

            return mapper.Map<Movie, MovieDTO>(movie);
        }
        public void Delete(int? id)
        {
            throw new NotImplementedException();
        }

    }
}
