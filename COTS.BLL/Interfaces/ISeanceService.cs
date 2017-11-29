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
        void AddOrUpdate(Seance seance);
        IEnumerable<SeanceDTO> FindByDate(DateTime date);
        IEnumerable<SeanceDTO> FindByMovie(long? movieId);
        IEnumerable<SeanceDTO> FindByCinema(long? cinemaId);
        void Delete(long? id);
    }
}
