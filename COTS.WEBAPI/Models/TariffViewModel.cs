using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace COTS.WEBAPI.Models
{
    public class TariffViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string WeekDay { get; set; }
        public string TimePeriod { get; set; }
        public string TechnologyId { get; set; }
        public long? SectorId { get; set; }
    }
}