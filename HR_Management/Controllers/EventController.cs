using HR_Management.DAL;
using HR_Management.Models;
using HR_Management.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq;
using System.Threading.Tasks;

namespace HR_Management.Controllers
{
    public class EventController : Controller
    {
        private AppDbContext _context { get; }

        public EventController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            EventVM events = new EventVM
            {
                Events = _context.Events.ToList()
            };
            ViewBag.ActivePage = "events";
            return View(events);
        }

        public IActionResult AllEvents()
        {
            var events = _context.Events.Select(e => new
            {
                id = e.Id,
                title = e.EventTitle,
                startDate = e.StartDate.ToString("dd/MM/yyyy"),
                endDate = e.EndDate.ToString("dd/MM/yyyy"),
                location = e.EventLocation
            });
            return new JsonResult(events);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Event evend)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (!(evend.EndDate >= evend.StartDate))
            {
                ModelState.AddModelError("EndDate", "* End date can't be sooner from Start date");
                return View();
            }
            await _context.Events.AddAsync(evend);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if(id == null)
            {
                return View();
            }
            var eventDb = await _context.Events.FindAsync(id);
            if(eventDb == null)
            {
                return NotFound();
            }
            _context.Events.Remove(eventDb);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
