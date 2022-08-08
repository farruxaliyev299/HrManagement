using HR_Management.DAL;
using HR_Management.Models;
using HR_Management.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace HR_Management.Controllers
{
    public class AttendanceController : Controller
    {
        private AppDbContext _context { get; }

        public AttendanceController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ViewBag.ActivePage = "attendance";
            AttendanceVM attendanceVM = new AttendanceVM
            {
                Attendances = _context.Attendances.ToList(),
                Employees = _context.Users.Where(user => !user.IsQuitted).ToList()
            };
            return View(attendanceVM);
        }
    }
}
