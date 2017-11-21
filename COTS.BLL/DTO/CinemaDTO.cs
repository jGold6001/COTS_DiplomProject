using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COTS.BLL.DTO
{
    public class CinemaDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }     
        public long CityId { get; set; }

        public CinemaDTO()
        {

        }

        public CinemaDTO(string name, string address)
        {
            Name = name;
            Address = address;
        }

        public CinemaDTO(string name, string address, long cityId) : this(name, address)
        {
            CityId = cityId;
        }
    }
}
