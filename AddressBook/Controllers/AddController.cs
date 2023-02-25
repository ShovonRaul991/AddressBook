using AddressBook.Data;
using AddressBook.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

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
            var AddressSelected = _context.Addresses.FirstOrDefault();
            return View(AddressSelected);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(string Name, string Email, long mobile, long landline, string website, string address)
        {
            Regex regexforEmail = new Regex(@"^[0-9a-z.\s+_]+@[0-9a-z-.+]+\.[a-z]{2,4}$",RegexOptions.CultureInvariant | RegexOptions.Singleline);


            if (Name != null && Email != null && landline != 0 && mobile != 0 && landline.ToString().Length == 10 && mobile.ToString().Length == 10 
                && website!=null && address!=null)
            {
                bool isValidEmail = regexforEmail.IsMatch(Email);
                if (isValidEmail)
                {
                    _context.Addresses.Add(new Address() { Name = Name, Email = Email, MobileNumber = mobile, LandLineNumber = landline, Website = website, AddressDetails = address });
                    _context.SaveChanges();
                    var SelectedAddress = _context.Addresses.OrderBy(e => e.Id).Last();
                    return RedirectToAction("Index", "Select", new { @id = SelectedAddress.Id });

                }

            }

            return RedirectToAction("Index", "Add");
            
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
