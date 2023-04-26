using ASM_APPLICATION_DEV.Enums;
using System.ComponentModel.DataAnnotations;

namespace ASM_APPLICATION_DEV.Models
{
	public class Category
	{
		[Key]
		public int Id { get; set; }
		public string NameCategory { get; set; } = string.Empty;
		public CategoryStatus Status { get; set; } = CategoryStatus.InProgess;
		public List<Book>? Books { get; set; }
	}
}