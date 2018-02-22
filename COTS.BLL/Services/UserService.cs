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
using COTS.DAL.Entities;

namespace COTS.BLL.Services
{
    public class UserService : IUserService
    {
        IUnitOfWork UnitOfWork { get; set; }
        MapperUnitOfWork mapperUnitOfWork;
        UserRepository userRepo;
        IUserDetailsService userDetailsService;

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
            var user = userRepo.Get(id);
            var userDTO = AttachObjetcToDTO(user);
            return userDTO;
        }

        public UserDTO GetOneByLogin(string login)
        {
            var user = userRepo.FindBy(u => u.Login == login).FirstOrDefault();
            var userDTO = AttachObjetcToDTO(user);
            return userDTO;
        }

        private bool IsAdmin(UserDTO userDTO)
        {
            if (userDTO.Login == "admin" && userDTO.Password == "admin")
                return true;

            return false;
        }

        private UserDTO AttachObjetcToDTO(User user)
        {
            userDetailsService = new UserDetailsService(this.UnitOfWork);
            var userDTO = mapperUnitOfWork.UserDTOMapper.MapToObject(user);
            userDTO.UserDetailsDTO = userDetailsService.GetOne(user.Id);
            return userDTO;
        }

       
    }
}
