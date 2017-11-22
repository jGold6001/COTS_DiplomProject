using COTS.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COTS.BLL.Interfaces
{
    public interface IMovieService
    {
        void AddOrUpdate(MovieDTO movieDTO);
        MovieDTO GetOne(int? id);
        IEnumerable<MovieDTO> GetAll();
        IEnumerable<MovieDTO> FindAllPremeries();
        IEnumerable<MovieDTO> FindAllComingSoon();
        IEnumerable<MovieDTO> GetTop10();      
        void Delete(int? id);
    }
}
