using HR_Management.DAL;
using HR_Management.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR_Management.Controllers
{
    [Authorize(Roles = "HR Admin")]
    public class DashboardController : Controller
    {
        private AppDbContext _context { get; }

        public DashboardController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.ActivePage = "dashboard";
            var employees = _context.Users.Where(emp => !emp.IsQuitted).ToList();
            return View(employees);
        }

        public IActionResult AddDoList()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddDoList(ToDoList doList)
        {
            //ToDoList create
            if (!_context.Users.Any(user => user.Id == doList.EmployeeId))
            {
                ModelState.AddModelError("", "Error");
            }
            if(_context.DoLists.Where(list => list.EmployeeId == doList.EmployeeId).Count() > 5)
            {
                ModelState.AddModelError("", "Maximum number of note is reached");
            }
            if (!ModelState.IsValid)
            {
                return View();
            }
            var newList = new ToDoList
            {
                Title = doList.Title,
                Description = doList.Description,
                EmployeeId = doList.EmployeeId,
            };
            await _context.DoLists.AddAsync(newList);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteDoList(int? id)
        {
            if(id == null)
            {
                return BadRequest();
            }
            var listDb = await _context.DoLists.FindAsync(id);
            if(listDb == null)
            {
                return NotFound();
            }
            _context.DoLists.Remove(listDb);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
