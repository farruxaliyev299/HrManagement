using HR_Management.DAL;
using HR_Management.Models;
using HR_Management.Utilities;
using HR_Management.ViewModels.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            }
            var signInResult = await _signInManager.PasswordSignInAsync(userDb, user.Password , user.isPersistent, lockoutOnFailure: true);
            if (!signInResult.Succeeded)
            {
                ModelState.AddModelError("" ,"Email or Password is incorrect");
            }
            if (!ModelState.IsValid)
            {
                return View(user);
            }
            if (signInResult.IsLockedOut)
            {
                ModelState.AddModelError("", "Too many failed attempts , Please try again in 5 minutes");
                return View();
            }
            return RedirectToAction("Index", "ProjectDashboard");
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login" , "Authentication");
        }

        public IActionResult ForgetPassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgetPassword(string email)
        {
            if (string.IsNullOrEmpty(email))
                return BadRequest();

            var isExists = await _userManager.Users.FirstOrDefaultAsync(x => x.IsQuitted == false && x.Email == email);
            if (isExists == null)
                return RedirectToAction("error", "dashboard");

            var token = await _userManager.GeneratePasswordResetTokenAsync(isExists);

            var link = Url.Action("ResetPassword", "Authentication", new { isExists.Id, token }, protocol: HttpContext.Request.Scheme);
            var message = $"<a href='{link}'>Click here</a>";

            await EmailUtils.SendEmailAsync(email, "Reset Password", message);
            return RedirectToAction("Login");
        }

        public async Task<IActionResult> ResetPassword(string id, string token)
        {
            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(token))
                return BadRequest();

            var isExists = await _userManager.Users.FirstOrDefaultAsync(x => x.IsQuitted == false && x.Id == id);

            if (isExists == null)
                return RedirectToAction("error", "dashboard");

            ResetPasswordViewModel resetPasswordVW = new ResetPasswordViewModel
            {
                Email = isExists.Email,
                Token = token
            };

            return View(resetPasswordVW);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(string id, ResetPasswordViewModel resetPasswordVW)
        {

            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(resetPasswordVW.Token))
                return BadRequest();
            if (string.IsNullOrEmpty(resetPasswordVW.NewPassword) || string.IsNullOrEmpty(resetPasswordVW.ConfirmPassword))
            {
                ModelState.AddModelError("", "New password and Confirm password is required");
            }
            if (!ModelState.IsValid)
            {
                return View();
            }
            var isExists = await _userManager.Users.FirstOrDefaultAsync(x => x.IsQuitted == false && x.Id == id);
            if (isExists == null)
                return RedirectToAction("error", "dashboard");
            var result = await _userManager.ResetPasswordAsync(isExists, resetPasswordVW.Token, resetPasswordVW.NewPassword);
            if (result.Errors == null)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View();
            }

            return RedirectToAction("Login");
        }
    }
}
