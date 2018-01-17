using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COTS.BLL.DTO
{
    public class MovieDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }        
        public string ImagePath { get; set; }
        public MovieDetailsDTO MovieDetailsDTO { get; set; }
        public int RankSales { get; set; }
        public DateTime DateIssue { get; set; }

    }
}
