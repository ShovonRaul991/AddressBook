using AddressBook.Data;
using AddressBook.Models;
using Microsoft.AspNetCore.Mvc;

namespace AddressBook.Controllers
{
    public class SelectController : Controller
    {
        private readonly AddressBookDbContext _context;

        public SelectController(AddressBookDbContext db)
        {
            _context = db;
        }

        public IActionResult Index(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var AddressSelected = _context.Addresses.Find(id);
            if (AddressSelected == null)
            {
                return NotFound();
            }
            return View(AddressSelected);
        }
    }
}