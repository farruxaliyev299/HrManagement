using HR_Management.DAL;
using HR_Management.Models;
using HR_Management.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HR_Management.Controllers
{
    [Authorize(Roles = "HR Admin")]
    public class HolidayController : Controller
    {
        private AppDbContext _context { get; }

        public HolidayController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            HolidayVM holiday = new HolidayVM
            {
                Holidays = _context.Holidays.ToList()
            };
            ViewBag.ActivePage = "holidays";
            return View(holiday);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Holiday holiday)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (!(holiday.EndDate >= holiday.StartDate))
            {
                ModelState.AddModelError("EndDate", "* End date can't be sooner from Start date");
                return View();
            }
            await _context.Holidays.AddAsync(holiday);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if(id == null)
            {
                return BadRequest();
            }
            var holidayDb = _context.Holidays.Find(id);
            if (holidayDb == null)
            {
                return NotFound();
            }
            _context.Holidays.Remove(holidayDb);
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
            var holidayDb = await _context.Holidays.FindAsync(id);
            if(holidayDb == null)
            {
                return NotFound();
            }
            return View(holidayDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id , Holiday holiday)
        {
            if(id == null)
            {
                return BadRequest();
            }
            var holidayDb = await _context.Holidays.FindAsync(id);
            if(holidayDb == null)
            {
                return NotFound();
            }
            if (!(holiday.EndDate >= holiday.StartDate))
            {
                ModelState.AddModelError("EndDate", "* End date can't be sooner from Start date");
                return View();
            }
            holidayDb.StartDate = holiday.StartDate;
            holidayDb.EndDate = holiday.EndDate;
            holidayDb.HolidayName = holiday.HolidayName;
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
