using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerce_Assignment.Models
{
    public class Session
    {
        public Session()
        {
           
            Id = new Guid();
            Timestamp = DateTimeOffset.Now.ToUnixTimeSeconds();
        }
        public Guid Id { get; set; }       
        public long Timestamp { get; set; }
        public Guid UserId { get; set; }
        public virtual User User { get; set; }

    }
}

