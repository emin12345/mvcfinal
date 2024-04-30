using Microsoft.AspNetCore.Mvc;

namespace riode.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
