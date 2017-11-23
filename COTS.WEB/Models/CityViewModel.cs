using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace COTS.WEB.Models
{
    public class CityViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public CityViewModel()
        {

        }

        public CityViewModel(string id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}