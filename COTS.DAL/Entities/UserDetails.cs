using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COTS.DAL.Entities
{
    public class UserDetails
    {
        [Key]
        [ForeignKey("User")]
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public User User { get; set; }
        public UserDetails()
        {

        }
    
        public UserDetails(string firstName, string lastName, string position)
        {           
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Position = position;
        }
    }
}
