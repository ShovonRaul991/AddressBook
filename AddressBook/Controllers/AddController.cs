using AddressBook.Data;
using AddressBook.Models;
using Microsoft.AspNetCore.Mvc;

namespace AddressBook.Controllers
{
    public class AddController : Controller
    {
        private readonly AddressBookDbContext _context;

        public AddController(AddressBookDbContext db)
        {
            _context = db;
        }

        public IActionResult Index()
        {
            var AddressSelected = _context.Addresses.Find(1);
            return View(AddressSelected);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(string Name, string Email,long mobile, long landline,string website, string address)
        {
            IEnumerable<Address> AddressList = _context.Addresses.ToList();
            if (landline != 0 && mobile!=0 && landline.ToString().Length == 10 && mobile.ToString().Length == 10)
            {
                _context.Addresses.Add(new Address(){Name=Name,Email=Email,MobileNumber=mobile,LandLineNumber=landline,Website=website,AddressDetails=address});
                _context.SaveChanges();

            }
            return RedirectToAction("Index","Home");
            /*
            if (ModelState.IsValid)
            {
                _context.Addresses.Add(obj);
                _context.SaveChanges();
                return RedirectToAction("Index");

            }
            */
        }
    }
}
