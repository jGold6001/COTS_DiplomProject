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
        MovieDTO GetOne(long? id);
        IEnumerable<MovieDTO> GetAll();       
        IEnumerable<MovieDTO> FindAllPremeries();
        IEnumerable<MovieDTO> FindAllComingSoon();
        IEnumerable<MovieDTO> GetTop10();
        IEnumerable<MovieDTO> FindAllByCity(string cityId);
        IEnumerable<MovieDTO> FindAllPremeriesByCity(string cityId);
        IEnumerable<MovieDTO> FindAllComingSoonByCity(string cityId);
        IEnumerable<MovieDTO> GetTop10ByRankOrderByCity(string cityId);
        void Delete(long? id);
    }
}
