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
    public class UserDetailsService : IUserDetailsService
    {
        IUnitOfWork UnitOfWork { get; set; }
        MapperUnitOfWork mapperUnitOfWork;

        public UserDetailsService(IUnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
            this.mapperUnitOfWork = new MapperUnitOfWork();
        }

        public void AddOrUpdate(UserDetailsDTO userDetailsDTO)
        {
            throw new NotImplementedException();
        }

        public void Delete(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserDetailsDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public UserDetailsDTO GetOne(long id)
        {
            throw new NotImplementedException();
        }
    }
}
