using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COTS.DAL.Entities
{
    public class Sector
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; }
        public string Name { get; set; }
        public ICollection<Place> Places { get; set; }

        public Sector()
        {
            Places = new List<Place>();
        }

        public Sector(long id, string name)
        {
            this.Id = id;
            this.Name = name;
            Places = new List<Place>();
        }
    }
}
