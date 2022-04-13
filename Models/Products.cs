using System;
using System.ComponentModel.DataAnnotations;

namespace eCommence_Assignment.Models
{
    public class Products
    {
        public Products()  //constructor
        {
            Id = new Guid();
        }
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public string Description{ get; set; }

        [Required]
        public string ImageUrl { get; set; }
      
        [Required]
        public string Brand { get; set; }

        public virtual ProdctCategory CategoryName { get; set; }

        // icollection productkey


    }
}
