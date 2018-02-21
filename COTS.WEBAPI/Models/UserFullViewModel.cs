using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace COTS.WEBAPI.Models
{
    public class UserFullViewModel
    {
        public long Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string CinemaId { get; set; }
        public long UserRoleId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
    }
}