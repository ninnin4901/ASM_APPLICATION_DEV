using ASM_APPLICATION_DEV.Enums;
using System.ComponentModel.DataAnnotations;

namespace ASM_APPLICATION_DEV.Models
{
	public class Order
	{
		[Key]
		public int Id { get; set; }
		public string UserId { get; set; } = string.Empty;
		public User User { get; set; }
		public DateTime DateOrder { get; set; } = DateTime.Now;
		public int PriceOrder { get; set; }
		public OrderStatus StatusOrder { get; set; }
		public List<OrderDetail>? OrderDetails { get; set; }
	}
}