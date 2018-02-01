using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace COTS.WEBAPI.Models
{
    public class SeanceViewModel
    {
        public long Id { get; set; }
        public string DateSeance { get; set; }
        public string TimeBegin { get; set; }
        public string TechnologyId { get;set; }
        public MovieShortViewModel MovieShortViewModel { get; set; }
        public HallViewModel HallViewModel { get; set; }
        public IEnumerable<TariffViewModel> TariffViewModels { get; set; }
    }
}