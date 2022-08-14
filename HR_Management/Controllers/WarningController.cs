using HR_Management.DAL;
using HR_Management.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace HR_Management.Controllers
{
    [Authorize(Roles = "HR Admin")]
    public class WarningController : Controller
    {
        private AppDbContext _context { get; }

        public WarningController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ViewBag.ActivePage = "warning";
            WarningVM warningVM = new WarningVM()
            {
                Warnings = _context.Warnings.ToList(),
                Employees = _context.Users.Where(user => !user.IsQuitted).ToList()
            };
            return View(warningVM);
        }
    }
}
