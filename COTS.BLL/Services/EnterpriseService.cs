using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COTS.BLL.DTO;
using COTS.DAL.Interfaces;
using COTS.BLL.Utils.MapperManager;
using COTS.BLL.Interfaces;

namespace COTS.BLL.Services
{
    public class EnterpriseService : IEnterpriseService
    {
        IUnitOfWork UnitOfWork { get; set; }
        MapperUnitOfWork mapperUnitOfWork;

        public EnterpriseService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            mapperUnitOfWork = new MapperUnitOfWork();
        }

        public IEnumerable<EnterpriseDTO> GetAll()
        {
            return mapperUnitOfWork.EnterpriseDTOMapper.MapToCollectionObjects(UnitOfWork.Enterprises.GetAll());
        }

        public EnterpriseDTO GetOne(string id)
        {
            return mapperUnitOfWork.EnterpriseDTOMapper.MapToObject(UnitOfWork.Enterprises.Get(id));
        }
    }
}
