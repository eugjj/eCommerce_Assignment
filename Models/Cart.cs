using System;
using System.ComponentModel.DataAnnotations;

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
    }
}
