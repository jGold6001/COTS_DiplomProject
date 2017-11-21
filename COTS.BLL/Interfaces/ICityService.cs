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
        void AddOrUpdate(City city); 
        void Delete(int? id);
    }
}
