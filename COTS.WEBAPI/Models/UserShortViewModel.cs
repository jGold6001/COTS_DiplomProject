﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace COTS.WEBAPI.Models
{
    public class UserShortViewModel
    {
        public long Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string CinemaId { get; set; }
        public long UserRoleId { get; set; }
    }
}