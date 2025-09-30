using Microsoft.AspNetCore.Mvc;

namespace GameWeb.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
