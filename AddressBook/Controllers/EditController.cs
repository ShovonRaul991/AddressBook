using AddressBook.Data;
using AddressBook.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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

        public IActionResult Update(string Name, string Email, long mobile, long landline, string website, string address, int id) 
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var AddressSelected = _context.Addresses.Find(id);
            if (landline != 0 && mobile != 0 && landline.ToString().Length == 10 && mobile.ToString().Length == 10)
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
            return RedirectToAction("Index", "Home");

        }

        
    }
}
