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
        // timestamp to be used for show user date of purchase
        public long CreateTimestamp { get; set; }
        public string Users { get; set; }
        public string Products { get; set; }
        //public virtual ICollection<Products> Products { get; set; }
        //public virtual ICollection<User> Users { get; set; }
    }
}