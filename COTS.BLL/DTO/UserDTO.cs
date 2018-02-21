﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COTS.BLL.DTO
{
    public class UserDTO
    {
        public long Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string CinemaId { get; set; }
        public long UserRoleId { get; set; }
        public UserDetailsDTO UserDetailsDTO { get; set; }
    }
}
