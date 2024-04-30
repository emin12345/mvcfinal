using Microsoft.AspNetCore.Mvc;

namespace riode.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
