using HR_Management.DAL;
using HR_Management.Models;
using HR_Management.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR_Management.Controllers
{
    public class StatusController : Controller
    {
        private AppDbContext _context { get; }

        public StatusController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            StatusVM statusVM = new StatusVM
            {
                Statuses = _context.Statuses.ToList()
            };
            ViewBag.ActivePage = "status";
            return View(statusVM);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Status status)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _context.Statuses.AddAsync(status);
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
            var statusDb = _context.Statuses.Find(id);
            if (statusDb == null)
            {
                return NotFound();
            }
            _context.Statuses.Remove(statusDb);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var statusDb = await _context.Statuses.FindAsync(id);
            if (statusDb == null)
            {
                return NotFound();
            }
            return View(statusDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id , Status status)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var statusDb = _context.Statuses.Find(id);
            if (statusDb == null)
            {
                return NotFound();
            }
            statusDb.StatusName = status.StatusName;
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
