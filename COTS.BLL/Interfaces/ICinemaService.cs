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
        CinemaDTO GetOne(string id);
        IEnumerable<CinemaDTO> FindAllByCity(string id);        
        void Delete(string id);       
    }
}
