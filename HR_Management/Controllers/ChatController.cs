using HR_Management.DAL;
using HR_Management.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace HR_Management.Controllers
{
    public class ChatController : Controller
    {
        private AppDbContext _context { get; }

        public ChatController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ViewBag.ActiveTab = "project";
            ViewBag.ActivePage = "chat";

            List<EmployeeUser> employees = _context.Users.ToList();
            return View(employees);
        }
    }
}
