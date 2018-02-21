using COTS.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COTS.BLL.DTO;
using COTS.BLL.Managers.MapperManager;
using COTS.DAL.Interfaces;

namespace COTS.BLL.Services
{
    public class UserRoleService : IUserRoleService
    {
        IUnitOfWork UnitOfWork { get; set; }
        MapperUnitOfWork mapperUnitOfWork;

        public UserRoleService(IUnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
            this.mapperUnitOfWork = new MapperUnitOfWork();
        }

        public void AddOrUpdate(UserRoleDTO userRoleDTO)
        {
            throw new NotImplementedException();
        }

        public void Delete(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserRoleDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public UserRoleDTO GetOne(long id)
        {
            throw new NotImplementedException();
        }
    }
}
