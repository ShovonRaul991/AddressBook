using Microsoft.AspNetCore.Mvc;

namespace AddressBook.Controllers
{
    public class AddController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
