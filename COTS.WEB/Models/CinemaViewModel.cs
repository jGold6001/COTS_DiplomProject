using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace COTS.WEB.Models
{
    public class CinemaViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string CityId { get; set; }

        public CinemaViewModel()
        {

        }

        public CinemaViewModel(string name, string address)
        {
            Name = name;
            Address = address;
        }

        public CinemaViewModel(string name, string address, string cityId) : this(name, address)
        {
            CityId = cityId;
        }
    }
}