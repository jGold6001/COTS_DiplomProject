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
        IEnumerable<MovieDTO> FindAllPremeries();
        IEnumerable<MovieDTO> FindAllComingSoon();
        IEnumerable<MovieDTO> GetTop10();
        void Delete(int id);
    }
}
