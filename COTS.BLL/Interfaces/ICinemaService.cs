using COTS.BLL.DTO;
using COTS.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COTS.BLL.Interfaces
{
    public interface ICinemaService
    {
        void AddOrUpdate(CinemaDTO cinemaDTO);
        IEnumerable<CinemaDTO> FindAllByCity(string cityName);        
        void Delete(int? id);
    }
}
