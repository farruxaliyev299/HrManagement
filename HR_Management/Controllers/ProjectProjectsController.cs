using HR_Management.DAL;
using HR_Management.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace HR_Management.Controllers
{
    public class ProjectProjectsController : Controller
    {
        private AppDbContext _context { get; }
        private UserManager<EmployeeUser> _userManager { get; }

        public ProjectProjectsController(AppDbContext context, UserManager<EmployeeUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.ActivePage = "project-pr";
            ViewBag.ActiveTab = "project";

            EmployeeUser loggedUser = null;
            if (User.Identity.IsAuthenticated)
            {
                loggedUser = await _userManager.FindByNameAsync(User.Identity.Name);
            }
            var projects = _context.Projects.Where(pr => pr.ProjectEmployees.Any(ep => ep.EmployeeId == loggedUser.Id)).ToList();
            return View(projects);
        }

        public async Task<IActionResult> Team(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var projectDb = await _context.Projects.FindAsync(id);
            if (projectDb == null)
            {
                return NotFound();
            }
            var employeesDb = _context.Users.Where(user => user.ProjectEmployees.Any(ep => ep.ProjectId == projectDb.Id)).ToList();
            return View(employeesDb);
        }

        public async Task<IActionResult> Description(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var projectDb = await _context.Projects.FindAsync(id);
            return View(projectDb);
        }
    }
}
