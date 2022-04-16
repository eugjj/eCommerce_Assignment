using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommence_Assignment.Models
{
    public class transactionID
    {
        public transactionID()
        {
            Id = new Guid();
        }
        public Guid Id { get; set; }
        // generated product in string format
        public string transID { get; set; }
        // timestamp to be used for show user date of purchase
        public long CreateTimestamp { get; set; }
        public string Users { get; set; }
        public Guid ProductId { get; set; }
        public int qty {get; set; }
        //public virtual ICollection<Products> Products { get; set; }
        //public virtual ICollection<User> Users { get; set; }
    }
}
 
