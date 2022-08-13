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
    public class DepartmentController : Controller
    {
        private AppDbContext _context { get; }

        public DepartmentController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ViewBag.ActivePage = "department";
            ViewBag.Department = _context.Departments.ToList();
            List<Department> departments = _context.Departments.ToList();
            foreach(var dep in departments)
            {
                dep.DepartmentCount = _context.Users.Where(user => !user.IsQuitted && user.DepartmentId == dep.Id).Count();
                if(_context.Users.Where(user => !user.IsQuitted && user.DepartmentId == dep.Id && user.IsHead ).Count() > 0)
                {
                    dep.DepartmentHead = _context.Users.FirstOrDefault(user => !user.IsQuitted && user.DepartmentId == dep.Id && user.IsHead).FullName;
                }
                else
                {
                    dep.DepartmentHead = string.Empty;
                }
            }
            _context.SaveChanges();
            return View(departments);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Department department)
        {
            if (!ModelState.IsValid)
            {
                return View(department);
            }
            if (!department.DepartmentName.Any(letter => char.IsLetter(letter)))
            {
                ModelState.AddModelError("DepartmentName", "Department name needs to contain atleast one letter");
                return View(department);
            }
            Department newDepartment = new Department
            {
                DepartmentName = department.DepartmentName,
                DepartmentCount = 0
            };
            await _context.Departments.AddAsync(newDepartment);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var departmentDb = _context.Departments.Find(id);
            if (departmentDb == null)
            {
                return NotFound();
            }
            if (departmentDb.DepartmentCount > 0)
            {
                return RedirectToAction("index");
            }
            _context.Departments.Remove(departmentDb);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int? id)
        {
            if(id == null)
            {
                return BadRequest();
            }
            var departmentDb = await _context.Departments.FindAsync(id);
            if (departmentDb == null)
            {
                return NotFound();
            }
            return View(departmentDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id , Department department)
        {
            if(id == null)
            {
                return BadRequest();
            }
            var departmentDb = await _context.Departments.FindAsync(id);
            if(departmentDb == null)
            {
                return NotFound();
            }
            if (!department.DepartmentName.Any(letter => char.IsLetter(letter)))
            {
                ModelState.AddModelError("DepartmentName", "Department name needs to contain atleast one letter");
                return View(department);
            }
            departmentDb.DepartmentName = department.DepartmentName;
            _context.Departments.Update(departmentDb);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
