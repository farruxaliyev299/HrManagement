using HR_Management.DAL;
using HR_Management.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR_Management.Controllers
{
    public class ChatController : Controller
    {
        private AppDbContext _context { get; }
        private UserManager<EmployeeUser> _userManager { get; set; }

        public ChatController(AppDbContext context, UserManager<EmployeeUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.ActiveTab = "project";
            ViewBag.ActivePage = "chat";

            EmployeeUser loggedUser = null;
            if (User.Identity.IsAuthenticated)
            {
                loggedUser = await _userManager.FindByNameAsync(User.Identity.Name);
            }
            List<EmployeeUser> employees = _context.Users.Where(user => user.Id != loggedUser.Id).ToList();
            return View(employees);
        }

        public async Task<IActionResult> SendMessage([FromBody] SendMessage message)
        {
            if (message == null || string.IsNullOrWhiteSpace(message.Text))
                return BadRequest();
            var fromUser = await _userManager.FindByNameAsync(User.Identity.Name);
            message.FromUserId = fromUser.Id;
            message.createdAt = DateTime.UtcNow;
            _context.SendMessages.Add(message);
            _context.SaveChanges();
            return Ok();
        }

        public async Task<IActionResult> GetData([FromBody] string id)
        {
            var currentUser = await _userManager.FindByNameAsync(User.Identity.Name);
            var messageData = _context.SendMessages.Where(x => (x.ToUserId == currentUser.Id && x.FromUserId == id) || (x.FromUserId == currentUser.Id && x.ToUserId == id)).ToList();
            return Ok(messageData);
        }
    }
}
