using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using COTS.BLL.DTO;
using COTS.DAL.Entities;

namespace COTS.BLL.Managers.MapperManager.DTOMappers
{
    public class UserRoleDTOMapper : GeneralMapper<UserRole, UserRoleDTO>
    {
        public UserRoleDTOMapper()
        {
            Mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<UserRole, UserRoleDTO>()));
        }

        public override IEnumerable<UserRoleDTO> MapToCollectionObjects(IEnumerable<UserRole> collectValues)
        {
            return Mapper.Map<IEnumerable<UserRole>, IEnumerable<UserRoleDTO>>(collectValues);
        }

        public override UserRoleDTO MapToObject(UserRole value)
        {
            return Mapper.Map<UserRole, UserRoleDTO>(value);
        }
    }
}
