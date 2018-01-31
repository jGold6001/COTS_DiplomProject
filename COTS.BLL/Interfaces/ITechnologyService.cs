using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COTS.BLL.DTO;
using COTS.DAL.Entities;

namespace COTS.BLL.Interfaces
{
    public interface ITechnologyService
    {
        TechnologyDTO GetOne(string id);
        IEnumerable<TechnologyDTO> GetAll();
    }
}
