using COTS.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COTS.BLL.Interfaces
{
    public interface IMovieDetailsService
    {
        void AddOrUpdate(MovieDetailsDTO movieDetailsDTO);
        MovieDetailsDTO GetOne(long? id);
        IEnumerable<MovieDetailsDTO> GetAll();
        void Delete(long? id);
    }
}
