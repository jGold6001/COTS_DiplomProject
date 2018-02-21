using COTS.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COTS.BLL.Interfaces
{
    public interface IUserRoleService
    {
        void AddOrUpdate(UserRoleDTO userRoleDTO);
        void Delete(long id);
        IEnumerable<UserRoleDTO> GetAll();
        UserRoleDTO GetOne(long id);

    }
}
