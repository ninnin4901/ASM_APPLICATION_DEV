using ASM_APPLICATION_DEV.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ASM_APPLICATION_DEV.ViewModel
{
	public class Cart
	{
		[BindProperty]
		public List<OrderDetail> orderDetails { get; set; }
		public int totalPrice { get; set; }
		
	}
}
