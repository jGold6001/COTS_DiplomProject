using COTS.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COTS.DAL.Test.CollectionForData.Technologies
{
    public static class TechnologiesCollection
    {
        public static List<Technology> Get()
        {
            return new List<Technology>()
            {
                new Technology("2d", "2D"),
                new Technology("3d", "3D")
            }; 
        }
    }
}
