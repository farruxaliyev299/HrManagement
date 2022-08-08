using Microsoft.AspNetCore.Mvc;

namespace HR_Management.Controllers
{
    public class DashboardController : Controller
    {

        public IActionResult Index()
        {
            ViewBag.ActivePage = "dashboard";
            return View();
        }
    }
}
