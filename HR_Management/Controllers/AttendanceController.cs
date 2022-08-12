using HR_Management.DAL;
using HR_Management.Models;
using HR_Management.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            ViewBag.Employees = _context.Users.Where(user => !user.IsQuitted).ToList();
            AttendanceVM attendanceVM = new AttendanceVM
            {
                Attendances = _context.Attendances.ToList(),
                Employees = _context.Users.Where(user => !user.IsQuitted).ToList(),
                Holidays = _context.Holidays.ToList()
            };
            return View(attendanceVM);
        }

        [HttpGet]
        public IActionResult Create()
        {
            AttendanceVM attendanceVM = new AttendanceVM
            {
                Employees = _context.Users.Include(db => db.Department).Where(user => !user.IsQuitted).ToList(),
            };
            return View(attendanceVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AttendanceVM attendanceVM)
        {
            bool checkHoliday = false;
            List<DateTime> holidayDays = new List<DateTime>();
            foreach (var hld in _context.Holidays.ToList())
            {
                for (var dt = hld.StartDate; dt <= hld.EndDate; dt = dt.AddDays(1))
                {
                    holidayDays.Add(dt);
                }
            }

            foreach (var atd in attendanceVM.Attendances)
            {
                Attendance attendance = new Attendance
                {
                    Date = DateTime.UtcNow,
                    AttendanceStatus = atd.AttendanceStatus,
                    EmployeeId = atd.EmployeeId,
                    Employee = atd.Employee,
                };
                
                if (_context.Attendances.Any(atd => atd.EmployeeId == attendance.EmployeeId && atd.Date.Date == attendance.Date.Date && atd.AttendanceStatus != null))
                {

                }
                else
                {
                    foreach (var day in holidayDays)
                    {
                        if (attendance.Date.Date == day.Date)
                        {
                            checkHoliday = true;
                        }
                    }
                    if (checkHoliday)
                    {
                        continue;
                    }
                     _context.Attendances.Add(attendance);

                }
            }
            _context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
