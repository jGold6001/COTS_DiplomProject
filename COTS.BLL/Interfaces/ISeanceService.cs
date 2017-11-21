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
        IEnumerable<Seance> FindByDate(DateTime date);
        IEnumerable<Seance> FindByMovie(string movieName);
        IEnumerable<Seance> FindByCinema(string cinemaName);
        void Delete(int? id);
    }
}
