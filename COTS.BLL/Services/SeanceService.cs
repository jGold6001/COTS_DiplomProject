using COTS.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COTS.DAL.Entities;

namespace COTS.BLL.Services
{
    public class SeanceService : ISeanceService
    {
        public void AddOrUpdate(Seance seance)
        {
            throw new NotImplementedException();
        }

        public void Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Seance> FindByCinema(string cinemaName)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Seance> FindByDate(DateTime date)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Seance> FindByMovie(string movieName)
        {
            throw new NotImplementedException();
        }
    }
}
