using HR_Management.DAL;
using HR_Management.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR_Management.Controllers
{
    public class LeaveRequestController : Controller
    {
        private AppDbContext _context { get; }

        public LeaveRequestController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ViewBag.ActivePage = "leaves";
            List<Leave> leaves = _context.Leaves.ToList();
            return View(leaves);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Leave leave)
        {
            if(leave.EndDate.Date < leave.StartDate.Date)
            {
                ModelState.AddModelError("EndDate", "End Date can't be sooner than Start Date");
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
            return RedirectToAction("Index" , "ProjectDashboard");
        }

        public async Task<IActionResult> IsAccepted(int? id)
        {
            if(id == null)
            {
                return BadRequest();
            }
            var leaveDb = await _context.Leaves.FindAsync(id);
            if (leaveDb == null)
            {
                return NotFound();
            }
            leaveDb.isAccepted = true;
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> IsDenied(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var leaveDb = await _context.Leaves.FindAsync(id);
            if (leaveDb == null)
            {
                return NotFound();
            }
            leaveDb.isAccepted = false;
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
