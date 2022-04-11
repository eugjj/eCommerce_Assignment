using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eCommence_Assignment.Models
{
    public class User
    {
        public User()
        {
            Id = new Guid();
            Products = new List<Products>();

        }

        public Guid Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public byte[] PassHash { get; set; }

       
        public virtual ICollection<Products> Products { get; set; }

    }
}
