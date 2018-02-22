using COTS.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COTS.BLL.Interfaces
{
    public interface IUserService
    {
        void AddOrUpdate(UserDTO userDTO);
        void Delete(long id);
        bool IsUserExist(UserDTO userDTO);
        IEnumerable<UserDTO> GetAllByCinema(string cinemaId);
        UserDTO GetOne(long id);
        UserDTO GetOneByLogin(string login);
    }
}
