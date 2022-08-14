using HR_Management.DAL;
using HR_Management.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace HR_Management.Controllers
{
    public class ProjectDashboardController : Controller
    {
        public AppDbContext _context { get; set; }

        public ProjectDashboardController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ViewBag.ActiveTab = "project";
            ViewBag.ActivePage = "dashboard-pr";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Leave leave)
        {
            if (leave.EndDate.Date < leave.StartDate.Date)
            {
                ModelState.AddModelError("EndDate", "End Date can't be sooner than Start Date");
            }
            if (!_context.Users.Any(user => user.Id == leave.EmployeeId))
            {
                ModelState.AddModelError("", "EmployeeID Error");
            }
            if (!ModelState.IsValid)
            {
                return View();
            }
            Leave newleave = new Leave
            {
                StartDate = leave.StartDate,
                EndDate = leave.EndDate,
                Reason = leave.Reason,
                EmployeeId = leave.EmployeeId
            };
            newleave.Employee = await _context.Users.FindAsync(leave.EmployeeId);
            _context.Leaves.Add(newleave);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
