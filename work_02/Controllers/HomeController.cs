using Microsoft.AspNetCore.Mvc;

namespace work_02.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
