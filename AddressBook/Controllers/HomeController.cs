using AddressBook.Data;
using AddressBook.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AddressBook.Controllers
{
    public class HomeController : Controller
    {
        /*
        private readonly ILogger<HomeController> _logger;
        
        
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        */

        private readonly AddressBookDbContext _context;

        public HomeController(AddressBookDbContext db)
        {
            _context = db;
        }
        
        public IActionResult Index()
        {
            var AddressSelected = _context.Addresses.Find(1);
            if(AddressSelected == null) 
            {
                return NotFound();
            }
            return View(AddressSelected);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}