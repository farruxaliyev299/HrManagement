using Microsoft.AspNetCore.Mvc;

namespace HR_Management.Controllers
{
    public class ProjectDashboardController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.ActiveTab = "project";
            ViewBag.ActivePage = "dashboard-pr";
            return View();
        }
    }
}
