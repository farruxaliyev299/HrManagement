using HR_Management.DAL;
using HR_Management.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR_Management.Controllers
{
    [Authorize(Roles = "HR Admin")]
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
            if (project.EndDate.Date <= project.StartDate.Date)
            {
                ModelState.AddModelError("EndDate", "Deadline can't be sooner than project's start date");
            }
            if (project.EmployeeIds != null)
            {
                foreach (var empId in project.EmployeeIds)
                {
                    if (!_context.Users.Any(user => user.Id == empId))
                    {
                        ModelState.AddModelError("EmployeeIds", "Employee doesn't found");
                    }
                    ProjectEmployee projectEmployee = new ProjectEmployee
                    {
                        EmployeeId = empId,
                    };
                    project.ProjectEmployees.Add(projectEmployee);
                }
            }
            if (!ModelState.IsValid)
            {
                ViewBag.Project = _context.Projects.Where(project => !project.isDone).ToList();
                ViewBag.Employees = _context.Users.Where(user => !user.IsQuitted).ToList();

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

        public async Task<IActionResult> Team(int? id)
        {
            if(id == null)
            {
                return BadRequest();
            }
            List<ProjectEmployee> ProjectEmployeeDb = new List<ProjectEmployee>();
            foreach (var ep in _context.ProjectEmployees.ToList())
            {
                if(ep.ProjectId == id)
                {
                    ProjectEmployeeDb.Add(ep);
                }
            }
            List<EmployeeUser> employees = new List<EmployeeUser>();
            foreach (var ep in ProjectEmployeeDb)
            {
                employees.Add(await _context.Users.FindAsync(ep.EmployeeId));
            }
            return View(employees);
        }

        public async Task<IActionResult> Description(int? id)
        {
            if(id == null)
            {
                return BadRequest();
            }
            var projectDb = await _context.Projects.FindAsync(id);
            if(projectDb == null)
            {
                return NotFound();
            }
            return View(projectDb);
        }

        public async Task<IActionResult> IsDone(int? id)
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
            projectDb.isDone = true;
            projectDb.FinishDate = System.DateTime.Now;
            if(projectDb.FinishDate < projectDb.EndDate)
            {
                projectDb.IsSuccesfull = true;
            }
            else
            {
                projectDb.IsSuccesfull = false;
            }
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
