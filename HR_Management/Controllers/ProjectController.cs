using HR_Management.DAL;
using HR_Management.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR_Management.Controllers
{
    public class ProjectController : Controller
    {
        private AppDbContext _context { get; }

        public ProjectController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ViewBag.Project = _context.Projects.Where(project => !project.isDone).ToList();
            ViewBag.Employees = _context.Users.Where(user => !user.IsQuitted).ToList();
            List<Project> projects = _context.Projects.Where(project => !project.isDone).ToList();
            return View(projects);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Project = _context.Projects.Where(project => !project.isDone).ToList();
            ViewBag.Employees = _context.Users.Where(user => !user.IsQuitted).ToList();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Project project)
        {
            if (!ModelState.IsValid)
            {
                return View(project);
            }
            if(project.EmployeeIds != null)
            {
                foreach (var empId in project.EmployeeIds)
                {
                    if (!_context.Users.Any(user => user.Id == empId))
                    {
                        ModelState.AddModelError("EmployeeIds", "Employee doesn't found");
                        return View();
                    }
                    ProjectEmployee projectEmployee = new ProjectEmployee
                    {
                        EmployeeId = empId,
                    };
                    project.ProjectEmployees.Add(projectEmployee);
                }
            }
            if(project.EndDate.Date <= project.StartDate.Date)
            {
                ModelState.AddModelError("EndDate", "Deadline can't be sooner than project's start date");
                return View(project);
            }
            await _context.Projects.AddAsync(project);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int? id)
        {
            if(id == null)
            {
                return BadRequest();
            }
            var projectDb = await _context.Projects.Include(db => db.ProjectEmployees).FirstOrDefaultAsync(pr => pr.Id == id);
            if(projectDb == null)
            {
                return NotFound();
            }
            projectDb.EmployeeIds = projectDb.ProjectEmployees.Select(pr => pr.EmployeeId).ToList();

            ViewBag.Project = _context.Projects.Where(project => !project.isDone).ToList();
            ViewBag.Employees = _context.Users.Where(user => !user.IsQuitted).ToList();
            return View(projectDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id , Project project)
        {
            if(id == null)
            {
                return BadRequest();
            }
            var projectDb = await _context.Projects.Include(db => db.ProjectEmployees).FirstOrDefaultAsync(pr => pr.Id == id);
            if(projectDb == null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return View(project);
            }

            projectDb.ProjectEmployees.RemoveAll(ep => !project.EmployeeIds.Contains(ep.EmployeeId));

            foreach (var empId in project.EmployeeIds.Where(empId => !projectDb.ProjectEmployees.Any(ep => ep.EmployeeId == empId)))
            {
                ProjectEmployee projectEmployee = new ProjectEmployee
                {
                    EmployeeId = empId
                };
                projectDb.ProjectEmployees.Add(projectEmployee);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
