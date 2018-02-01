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
using COTS.BLL.Utils;
using COTS.BLL.Managers.MapperManager;

namespace COTS.BLL.Services
{
    public class MovieService : IMovieService
    {
        IUnitOfWork UnitOfWork { get; set; }
        MovieRepository movieRepo;

        MapperUnitOfWork mapperUnitOfWork;

        IMovieDetailsService movieDetailsService;

        public MovieService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            movieRepo = unitOfWork.Movies as MovieRepository;
            mapperUnitOfWork = new MapperUnitOfWork();
            movieDetailsService = new MovieDetailsService(unitOfWork);
        }

        public void AddOrUpdate(MovieDTO movieDTO)
        {
            throw new NotImplementedException();
        }
       
      
        public IEnumerable<MovieDTO> GetAll()
        {
            var movies = AttachObjetcsToDTOList(movieRepo.GetAll());
            return movies;
        }

        public MovieDTO GetOne(long? id)
        {
            if (id == null)
                throw new ValidationException("Movie 'Id' not set", "");

            var movie = movieRepo.Get(id.Value);
            if (movie == null)
                throw new ValidationException("Movie not found","");

            var movieDTO =  AttachObjetcToDTO(movie);
            return movieDTO;
        }

        public void Delete(long? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MovieDTO> FindAllByCity(string cityId)
        {
            if (cityId == null)
                throw new ValidationException("'CityId' not set", "");

            var movies = movieRepo.FindAllByCity(cityId);
            if(movies.Count() == 0)
                throw new ValidationException("Movies not found", "");

            var moviesDTOs = AttachObjetcsToDTOList(movies);
            return moviesDTOs;
        }

        public IEnumerable<MovieDTO> FindAllPremeriesByCity(string cityId)
        {
            if (cityId == null)
                throw new ValidationException("'CityId' not set", "");

            var movies = movieRepo.FindAllPremeriesByCity(cityId);
            var moviesDTOs = AttachObjetcsToDTOList(movies);
            return moviesDTOs;          
        }

        public IEnumerable<MovieDTO> FindAllComingSoonByCity(string cityId)
        {
            if (cityId == null)
                throw new ValidationException("'CityId' not set", "");


            var movies = movieRepo.FindAllComingSoonByCity(cityId);
            var moviesDTOs = AttachObjetcsToDTOList(movies);
            return moviesDTOs;
        }

        public IEnumerable<MovieDTO> GetTop10ByRankOrderByCity(string cityId)
        {
            if (cityId == null)
                throw new ValidationException("'CityId' not set", "");

            var movies = movieRepo.GetTop10ByRankOrderByCity(cityId);
            var moviesDTOs = AttachObjetcsToDTOList(movies);
            return moviesDTOs;
        }



        private IEnumerable<MovieDTO> AttachObjetcsToDTOList(IEnumerable<Movie> movies)
        {           
            var moviesDTOs = mapperUnitOfWork.MovieDTOMapper.MapToCollectionObjects(movies);
            foreach (var item in moviesDTOs)
                item.MovieDetailsDTO = movieDetailsService.GetOne(item.Id);

            return moviesDTOs;
        }

        private MovieDTO AttachObjetcToDTO(Movie movie)
        {
            var movieDTO = mapperUnitOfWork.MovieDTOMapper.MapToObject(movie);
            movieDTO.MovieDetailsDTO = movieDetailsService.GetOne(movieDTO.Id);
            return movieDTO;
        }
    }
}
