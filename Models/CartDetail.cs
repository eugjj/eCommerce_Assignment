using System;
using System.ComponentModel.DataAnnotations;
using System.Collections;
using System.Collections.Generic;

namespace eCommence_Assignment.Models
{
	public class CartDetail
	{
		public CartDetail()
		{
			Id = new Guid();
		}
		public Guid Id { get; set; }
		[Required]
		public string CartId { get; set; }

		public int ProductId { get; set; }

		[Required]
		public string UserId { get; set; }

		public int Quantity { get; set; }

		public virtual Products Products { get; set; }
	}
}