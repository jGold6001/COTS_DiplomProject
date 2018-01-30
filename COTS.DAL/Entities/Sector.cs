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
        public string WeekDay { get; set; }
        public string TimePeriod { get; set; }
        public string EnterpriseId { get; set; }
        public Enterprise Enterprise { get; set; }
        public ICollection<Place> Places { get; set; }
        public ICollection<Tariff> Tariffs { get; set; }

        public Sector()
        {
            Places = new List<Place>();
            Tariffs = new List<Tariff>();
        }

        public Sector(long id, string name, string EnterpriseId)
        {
            this.Id = id;
            this.Name = name;
            this.EnterpriseId = EnterpriseId;
            Places = new List<Place>();
            Tariffs = new List<Tariff>();
        }
    }
}
