﻿using COTS.BLL.Interfaces;
using COTS.WEBAPI.Models;
using COTS.WEBAPI.Utils.MapperManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace COTS.WEBAPI.Controllers.WebApi
{
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        IUserService userService;
        MapperUnitOfWork mapperUnitOfWork;

        public UserController()
        {

        }

        public UserController(IUserService userService)
        {
            this.userService = userService;
            mapperUnitOfWork = new MapperUnitOfWork();
        }

        [HttpPost]
        [Route("is_exist")]      
        public IHttpActionResult IsUserExist(UserShortViewModel userShortViewModel)
        {
            var userDTO = mapperUnitOfWork.UserDTOMapper.MapToObject(userShortViewModel);
            if (userService.IsUserExist(userDTO))
                return Ok();

            return BadRequest();
        }
    }
}
