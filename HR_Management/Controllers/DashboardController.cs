using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HR_Management.Controllers
{
    [Authorize(Roles = "HR Admin")]
    public class DashboardController : Controller
    {

        public IActionResult Index()
        {
            ViewBag.ActivePage = "dashboard";
            return View();
        }
    }
}
