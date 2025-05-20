using Microsoft.AspNetCore.Mvc;

namespace PKX.Controllers
{
    public class TesteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}
