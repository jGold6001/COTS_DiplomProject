using COTS.BLL.DTO;
using COTS.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COTS.BLL.Interfaces
{
    public interface ISeanceService
    {
        void AddOrUpdate(SeanceDTO seance);
        IEnumerable<SeanceDTO> FindByMovieAndDate(long? movieId, DateTime date);
        IEnumerable<SeanceDTO> FindByCinemaAndDate(string cinemaId, DateTime date);
        IEnumerable<SeanceDTO> FindAllByCinemaMovieAndDate(string cinemaId, long? movieId, DateTime date);
        void Delete(long? id);
    }
}
