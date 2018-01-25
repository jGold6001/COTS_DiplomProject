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
        public bool IsBusy { get; set; }
        public long? HallId { get; set; }
        public Hall Hall { get; set; }
        public ICollection<Tariff> Tariffs { get; set; }

        public Place()
        {
            Tariffs = new List<Tariff>();
        }

        public Place(long id, int row, int number, bool isBusy, long hallId)
        {
            this.Id = id;
            this.Row = row;
            this.Number = number;
            this.IsBusy = isBusy;
            this.HallId = hallId;
            Tariffs = new List<Tariff>();
        }
    }
}
