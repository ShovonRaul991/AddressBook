using AddressBook.Data;
using Microsoft.AspNetCore.Mvc;

namespace AddressBook.Controllers
{
    public class DeleteController : Controller
    {
        private readonly AddressBookDbContext _context;

        public DeleteController(AddressBookDbContext db)
        {
            _context = db;
        }
        public IActionResult Index(int id)
        {
            var x = _context.Addresses.Where(x => x.Id == id).ToList()[0];
            _context.Addresses.Remove(x);
            _context.SaveChanges();
            return RedirectToAction("Index","Home");
        }
    }
}
