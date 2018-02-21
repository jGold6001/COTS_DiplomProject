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
    public class UserDetailsDTOMapper : GeneralMapper<UserDetails, UserDetailsDTO>
    {
        public UserDetailsDTOMapper()
        {
            Mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<UserDetails, UserDetailsDTO>()));
        }

        public override IEnumerable<UserDetailsDTO> MapToCollectionObjects(IEnumerable<UserDetails> collectValues)
        {
            return Mapper.Map<IEnumerable<UserDetails>, IEnumerable<UserDetailsDTO>>(collectValues);
        }

        public override UserDetailsDTO MapToObject(UserDetails value)
        {
            return Mapper.Map<UserDetails, UserDetailsDTO>(value);
        }
    }
}
