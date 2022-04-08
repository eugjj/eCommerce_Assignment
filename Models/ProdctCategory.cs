using System;
using System.ComponentModel.DataAnnotations;

namespace eCommence_Assignment.Models
{
    public class ProdctCategory
    {
        public ProdctCategory()
        {
            Id = new Guid();
        }

        public Guid Id { get; set; }

        [Required]
        public string CategoryName { get; set; }
        
    }
}
