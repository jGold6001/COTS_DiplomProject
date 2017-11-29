using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COTS.BLL.DTO
{
    public class SeanceDTO
    {
        public long Id { get; set; }
        public DateTime DateAndTime { get; set; }
        public string TypeD { get; set; }
        public string Hall { get; set; }      
        public string CinemaId { get; set; }
        public long MovieId { get; set; }       
    }
}
