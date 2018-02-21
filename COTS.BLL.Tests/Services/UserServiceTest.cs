using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using COTS.DAL.Interfaces;
using COTS.BLL.Interfaces;
using COTS.DAL.Repositories;
using COTS.BLL.Services;
using COTS.BLL.DTO;

namespace COTS.BLL.Tests.Services
{
    [TestClass]
    public class UserServiceTest
    {
        IUnitOfWork unitOfWork;
        IUserService userService;

        [TestInitialize]
        public void Init()
        {
            unitOfWork = new EFUnitOfWork("CotsContext");
            userService = new UserService(unitOfWork);
        }

        [TestMethod]
        public void IsUserExist_TRUE_Test()
        {
            UserDTO userDTO = new UserDTO()
            {
                CinemaId = "florence",
                UserRoleId = 1,
                Login = "JayFlorence_A",
                Password = "adminQWERTY"
            };

            var result = userService.IsUserExist(userDTO);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsUserExist_FALSE_WrongLogin_Test()
        {
            UserDTO userDTO = new UserDTO()
            {
                CinemaId = "florence",
                UserRoleId = 1,
                Login = "JayFlorence_A12121",
                Password = "adminQWERTY"
            };

            var result = userService.IsUserExist(userDTO);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsUserExist_FALSE_WrongPassword_Test()
        {
            UserDTO userDTO = new UserDTO()
            {
                CinemaId = "florence",
                UserRoleId = 1,
                Login = "JayFlorence_A",
                Password = "adminQWERTY21212"
            };

            var result = userService.IsUserExist(userDTO);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsUserExist_FALSE_WrongPasswordAndLogin_Test()
        {
            UserDTO userDTO = new UserDTO()
            {
                CinemaId = "florence",
                UserRoleId = 1,
                Login = "JayFlorence_A2121212",
                Password = "adminQWERTY21212"
            };

            var result = userService.IsUserExist(userDTO);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsUserExist_TRUE_isAdmin_Test()
        {
            UserDTO userDTO = new UserDTO()
            {              
                UserRoleId = 1,
                Login = "admin",
                Password = "admin"
            };

            var result = userService.IsUserExist(userDTO);
            Assert.IsTrue(result);
        }
    }
}
