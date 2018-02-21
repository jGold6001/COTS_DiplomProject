using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using COTS.BLL.DTO;
using COTS.WEBAPI.Models;

namespace COTS.WEBAPI.Utils.MapperManager.DTOMappers
{
    public class UserDTOMapper : GeneralMapper<UserShortViewModel, UserDTO>
    {
        public UserDTOMapper()
        {
            Mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<UserShortViewModel, UserDTO>()));
        }

        public override IEnumerable<UserDTO> MapToCollectionObjects(IEnumerable<UserShortViewModel> collectValues)
        {
            return Mapper.Map<IEnumerable<UserShortViewModel>, IEnumerable<UserDTO>>(collectValues);
        }

        public override UserDTO MapToObject(UserShortViewModel value)
        {
            return Mapper.Map<UserShortViewModel, UserDTO>(value);
        }
    }
}