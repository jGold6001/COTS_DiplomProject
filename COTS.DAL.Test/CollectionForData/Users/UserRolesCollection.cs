using COTS.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COTS.DAL.Test.CollectionForData.Users
{
    public static class UserRolesCollection
    {
        public static List<UserRole> Get()
        {
            return new List<UserRole>()
            {
                new UserRole(1, "administrator"),
                new UserRole(2, "worker")
            };
        }
    }
}
