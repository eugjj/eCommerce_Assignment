using System;
using System.ComponentModel.DataAnnotations;
using System.Collections;
using System.Collections.Generic;

namespace eCommence_Assignment.Models
{
    public class Cart
    {
        public Cart()
        {
            Id = new Guid();
        }
        public Guid Id { get; set; }

        [Required]
        public Guid ProductId { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<CartDetail> Collection { get; set; }
    }
}
