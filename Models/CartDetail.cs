using System;
using System.ComponentModel.DataAnnotations;
using System.Collections;
using System.Collections.Generic;

namespace eCommence_Assignment.Models

public class CartDetail
{
	public string CartId { get; set; }
	public int ProductId { get; set; }
	public string UserId { get; set; }
	public int Quantity { get; set; }

	public virtual Products Products { get; set; }
}
