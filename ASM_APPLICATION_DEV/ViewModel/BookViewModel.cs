using ASM_APPLICATION_DEV.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ASM_APPLICATION_DEV.ViewModel
{
	public class BookViewModel
	{
		public Book Book { get; set; }
		public IEnumerable<Category>? Categories { get; set; }

		[Display(Name = "File")]
		public IFormFile? FormFile { get; set; }
	}
}
