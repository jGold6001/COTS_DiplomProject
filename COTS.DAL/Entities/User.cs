using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COTS.DAL.Entities
{
    public class User
    {
        public long Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public Cinema Cinema { get; set; }
        public string CinemaId { get; set; }
        public UserRole UserRole { get; set; }
        public UserDetails UserDetails { get; set; }
        public long UserRoleId { get; set; }

        public User()
        {

        }

        public User(string login, string password, string cinemaId, long userRoleId , UserDetails userDetails)
        {
            this.Login = login;
            this.Password = password;
            this.CinemaId = cinemaId;
            this.UserRoleId = userRoleId;
            this.UserDetails = userDetails;
        }
    }
}
