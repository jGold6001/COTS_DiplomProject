using COTS.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COTS.DAL.Entities;

namespace COTS.BLL.Services
{
    public class CinemaService : ICinemaService
    {
        public void AddOrUpdate(Cinema cinema)
        {
            throw new NotImplementedException();
        }

        public void Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cinema> FindAllByCity(string cityName)
        {
            throw new NotImplementedException();
        }
    }
}
