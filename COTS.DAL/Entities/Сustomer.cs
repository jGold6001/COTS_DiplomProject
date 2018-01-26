using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COTS.DAL.Entities
{
    public class Customer
    {     
        [Key]
        [ForeignKey("Purchase")]
        public string Id { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public long Phone { get; set; } 
        public Purchase Purchase { get; set; }

       
    }
}
