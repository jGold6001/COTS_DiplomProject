using AutoMapper;
using COTS.BLL.DTO;
using COTS.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COTS.BLL.Managers.MapperManager.DTOMappers
{
    public class UserDTOMapper : GeneralMapper<User, UserDTO>
    {
        public UserDTOMapper()
        {
            Mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTO>()));
        }

        public override IEnumerable<UserDTO> MapToCollectionObjects(IEnumerable<User> collectValues)
        {
            return Mapper.Map<IEnumerable<User>, IEnumerable<UserDTO>>(collectValues);
        }

        public override UserDTO MapToObject(User value)
        {
            return Mapper.Map<User, UserDTO>(value);
        }
    }
}
