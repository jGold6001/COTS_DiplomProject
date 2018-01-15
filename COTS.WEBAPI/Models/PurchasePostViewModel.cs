using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace COTS.WEBAPI.Models
{
    public class PurchasePostViewModel
    {
        public string Id { get; set; }
        public MovieViewModel MovieViewModel { get; set; }
        public CinemaViewModel GetCinemaViewModel { get; set; }
        public SeanceViewModel SeanceViewModel { get; set; }
        public List<TicketViewModel> TicketViewModels { get; set; }
    }
}