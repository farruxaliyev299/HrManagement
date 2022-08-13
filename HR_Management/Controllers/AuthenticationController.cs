using HR_Management.DAL;
using HR_Management.Models;
using HR_Management.ViewModels.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HR_Management.Controllers
{
    public class AuthenticationController : Controller
    {
        private AppDbContext _context { get; }
        private SignInManager<EmployeeUser> _signInManager { get; }
        private UserManager<EmployeeUser> _userManager { get; }

        public AuthenticationController(SignInManager<EmployeeUser> signInManager , UserManager<EmployeeUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM user)
        {
            var userDb = await _userManager.FindByEmailAsync(user.Email);
            if(userDb == null)
            {
                ModelState.AddModelError("", "Email or Password is incorrect");
                return View(user);
            }
            var signInResult = await _signInManager.PasswordSignInAsync(userDb, user.Password , user.isPersistent, lockoutOnFailure: true);
            if (!signInResult.Succeeded)
            {
                ModelState.AddModelError("" ,"Email or Password is incorrect");
                return View(user);
            }
            if (signInResult.IsLockedOut)
            {
                ModelState.AddModelError("", "Too many failed attempts , Please try again in 5 minutes");
                return View();
            }
            return RedirectToAction("Index", "Dashboard");
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login" , "Authentication");
        }
    }
}
