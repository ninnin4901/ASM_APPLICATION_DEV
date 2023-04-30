using ASM_APPLICATION_DEV.Data;
using ASM_APPLICATION_DEV.DTOs.Responses;
using ASM_APPLICATION_DEV.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using System.Diagnostics;

namespace ASM_APPLICATION_DEV.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()

        {
            List<BookView> listBookInHome = new List<BookView>();
            var booksToBuy = _context.Books.Include(t => t.Category).ToList();

            foreach (var item in booksToBuy)
            {
                BookView book = new BookView();
                book.Id = item.Id;
                book.NameBook = item.NameBook;
                book.QuantityBook = item.QuantityBook;
                book.PriceBook = item.Price;
                book.ImageBook = ConvertByteArrayToStringBase64(item.Image);
                listBookInHome.Add(book);
            }
            return View(listBookInHome);
        }

        [NonAction]
        private string ConvertByteArrayToStringBase64(byte[] imageArray)
        {
            string imageBase64Data = Convert.ToBase64String(imageArray);

            return string.Format("data:image/jpg;base64, {0}", imageBase64Data);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Help()
        {
            return View();
        }
    }
}