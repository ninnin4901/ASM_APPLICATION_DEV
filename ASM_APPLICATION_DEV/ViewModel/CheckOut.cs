using ASM_APPLICATION_DEV.Models;
using System.Collections.Generic;

namespace ASM_APPLICATION_DEV.ViewModel
{
	public class CheckOut
	{
		public string? Name { get; set; }
		public string? Address { get; set; }
		public string? Phone { get; set; }
		public List<OrderDetail> orderDetails { get; set; }
		public int TotalPrice { get; set; }

	}
}
