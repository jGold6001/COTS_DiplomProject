﻿using COTS.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace COTS.DAL.Repositories
{
    public class UserDetailsRepository : Repository<UserDetails>
    {
        public UserDetailsRepository(DbContext context) : base(context)
        {
        }
    }
}
