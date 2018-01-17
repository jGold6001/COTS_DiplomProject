using COTS.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COTS.BLL.DTO;
using COTS.DAL.Interfaces;
using COTS.BLL.Utils.MapperManager;

namespace COTS.BLL.Services
{
    public class MovieDetailsService : IMovieDetailsService
    {
        IUnitOfWork UnitOfWork { get; set; }

        MapperUnitOfWork mapperUnitOfWork;

        public MovieDetailsService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            mapperUnitOfWork = new MapperUnitOfWork();

        }

        public void AddOrUpdate(MovieDetailsDTO movieDetailsDTO)
        {
            throw new NotImplementedException();
        }

        public void Delete(long? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MovieDetailsDTO> GetAll()
        {
            return mapperUnitOfWork.MovieDetailsDTOMapper.MapToCollectionObjects(UnitOfWork.MovieDetailses.GetAll());
        }

        public MovieDetailsDTO GetOne(long? id)
        {
            return mapperUnitOfWork.MovieDetailsDTOMapper.MapToObject(UnitOfWork.MovieDetailses.Get(id));
        }
    }
}
