using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COTS.DAL.Entities
{
    public class Place
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; }
        public int Row { get; set; }
        public int Number { get; set; }       
        public long? HallId { get; set; }
        public Hall Hall { get; set; }      
        public long? SectorId { get; set; }
        public Sector Sector { get; set; }
        public Place()
        {
            
        }

        public Place(long id, int row, int number, long hallId, long sectorId)
        {
            this.Id = id;
            this.Row = row;
            this.Number = number;
            this.HallId = hallId;
            this.SectorId = sectorId;
        }
    }
}
