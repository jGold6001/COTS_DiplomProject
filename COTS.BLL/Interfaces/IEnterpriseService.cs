using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COTS.BLL.DTO;
using COTS.DAL.Entities;

namespace COTS.BLL.Interfaces
{
    public interface IEnterpriseService
    {
        EnterpriseDTO GetOne(string id);
        IEnumerable<EnterpriseDTO> GetAll();
    }
}
