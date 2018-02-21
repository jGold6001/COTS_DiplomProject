using COTS.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COTS.BLL.DTO;
using COTS.DAL.Interfaces;
using COTS.BLL.Managers.MapperManager;
using COTS.DAL.Repositories;

namespace COTS.BLL.Services
{
    public class UserService : IUserService
    {
        IUnitOfWork UnitOfWork { get; set; }
        MapperUnitOfWork mapperUnitOfWork;
        UserRepository userRepo;

        public UserService(IUnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
            this.mapperUnitOfWork = new MapperUnitOfWork();
            this.userRepo = UnitOfWork.Users as UserRepository;
        }

        public void AddOrUpdate(UserDTO userDTO)
        {
            throw new NotImplementedException();
        }

        public void Delete(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserDTO> GetAllByCinema(string cinemaId)
        {
            return mapperUnitOfWork.UserDTOMapper.MapToCollectionObjects(userRepo.FindBy(u => u.CinemaId == cinemaId)) ;
        }

        public bool IsUserExist(UserDTO userDTO)
        {
            var user = userRepo.FindBy(u => ((u.CinemaId == userDTO.CinemaId) && (u.Login == userDTO.Login) && (u.Password == userDTO.Password))).FirstOrDefault();
            var isAdmin = IsAdmin(userDTO);
            if (user != null || isAdmin)
                return true;

            return false;
        }

        public UserDTO GetOne(long id)
        {
            return mapperUnitOfWork.UserDTOMapper.MapToObject(userRepo.Get(id));
        }

        private bool IsAdmin(UserDTO userDTO)
        {
            if (userDTO.Login == "admin" && userDTO.Password == "admin")
                return true;

            return false;
        }
    }
}
