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
            if(_context.Addresses.Count()!=0)
            {
                var PreviousAddress = _context.Addresses.OrderBy(e => e.Id).Last();
                return RedirectToAction("Index", "Select", new { @id = PreviousAddress.Id });
            }
            return RedirectToAction("Index","Home");
        }
    }
}
