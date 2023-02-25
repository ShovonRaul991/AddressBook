using AddressBook.Data;
using AddressBook.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AddressBook.Controllers
{
    public class EditController : Controller
    {
        private readonly AddressBookDbContext _context;

        public EditController(AddressBookDbContext db)
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(string Name, string Email, long mobile, long landline, string website, string address, int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Regex regexforEmail = new Regex(@"^[0-9a-z.\s+_]+@[0-9a-z-.+]+\.[a-z]{2,4}$", RegexOptions.CultureInvariant | RegexOptions.Singleline);
            
            var AddressSelected = _context.Addresses.Find(id);
            if (Name != null && Email != null && landline != 0 && mobile != 0 && landline.ToString().Length == 10 && mobile.ToString().Length == 10
                && website != null && address != null)
            {
                bool isValidEmail = regexforEmail.IsMatch(Email);
                if (isValidEmail)
                {
                    var x = _context.Addresses.Where(p => p.Id == id);
                    x.ToList()[0].Name = Name;
                    x.ToList()[0].Email = Email;
                    x.ToList()[0].MobileNumber = mobile;
                    x.ToList()[0].LandLineNumber = landline;
                    x.ToList()[0].Website = website;
                    x.ToList()[0].AddressDetails = address;
                    _context.SaveChanges();

                }

            }
            return RedirectToAction("Index","Select", new { @id = AddressSelected?.Id });

        }


    }
}
