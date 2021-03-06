﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COTS.DAL.Entities
{
    public class Hall
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; }
        public string Name { get; set; }
        public string CinemaId { get; set; }
        public Cinema Cinema { get; set; }        

        public Hall()
        {
            
        }

        public Hall(long id, string name, string cinemaId)
        {
            this.Id = id;
            this.Name = name;
            this.CinemaId = cinemaId;          
        }
    }
}
