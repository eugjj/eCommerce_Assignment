using System;
using System.ComponentModel.DataAnnotations;
using System.Collections;
using System.Collections.Generic;

namespace eCommence_Assignment.Models
{
    public class ProductKey
    {
        public ProductKey()
        {
            Id = new Guid();                     
        }
        /* maps to primary key */
        public Guid Id { get; set; } 
        // generated product in string format
        public string PKey { get; set; }               
        public virtual Guid transactionIDs { get; set; }
        //public virtual ICollection<User> Users { get; set; }
    }
}