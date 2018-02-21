using COTS.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COTS.BLL.Interfaces
{
    public interface IUserDetailsService
    {
        void AddOrUpdate(UserDetailsDTO userDetailsDTO);
        void Delete(long id);
        IEnumerable<UserDetailsDTO> GetAll();
        UserDetailsDTO GetOne(long id);
    }
}
