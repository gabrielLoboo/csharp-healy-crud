using Microsoft.AspNetCore.Mvc;

namespace Healy_API.Controllers
{
    public class HomeController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
