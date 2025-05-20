using Microsoft.AspNetCore.Mvc;

namespace PKX.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
