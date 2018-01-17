using COTS.BLL.DTO;
using COTS.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COTS.BLL.Interfaces
{
    public interface ICityService
    {
        void AddOrUpdate(CityDTO city);
        CityDTO GetOne(string id);
        IEnumerable<CityDTO> GetAll();
        void Delete(string id);
    }
}
