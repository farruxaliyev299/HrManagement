using HR_Management.DAL;
using HR_Management.Models;
using HR_Management.Utilities;
using HR_Management.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR_Management.Controllers
{
    [Authorize(Roles = "HR Admin")]
    public class EmployeeController : Controller
    {
        private AppDbContext _context { get; }
        private UserManager<EmployeeUser> _userManager { get; }
        private RoleManager<IdentityRole> _roleManager { get; }
        private IWebHostEnvironment _env { get; }

        public EmployeeController(AppDbContext context , UserManager<EmployeeUser> userManager , RoleManager<IdentityRole> roleManager , IWebHostEnvironment env)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _env = env;
        }

        //public async Task<IActionResult> CreateRoles()
        //{
        //    await _roleManager.CreateAsync(new IdentityRole("HR Admin"));
        //    await _roleManager.CreateAsync(new IdentityRole("Employee"));
        //    return Ok();
        //}

        public IActionResult Index()
        {
            ViewBag.ActivePage = "employees";
            ViewBag.DepCheck = _context.Departments.Count() > 0;
            List<EmployeeUser> employees = _userManager.Users.Include(user => user.Status).Include(user => user.Gender).Include(user=> user.Department).Where(user => !user.IsQuitted).ToList();
            return View(employees);
        }

        [HttpGet]
        public IActionResult Create()
        {
            if(_context.Departments.Count() > 0)
            {
                ViewBag.Status = _context.Statuses.ToList();
                ViewBag.Gender = _context.Genders.ToList();
                ViewBag.Department = _context.Departments.ToList();
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateEmployeeUserVM employeeUser)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Status = _context.Statuses.ToList();
                ViewBag.Gender = _context.Genders.ToList();
                ViewBag.Department = _context.Departments.ToList();
                return View(employeeUser);
            }
            if (!employeeUser.Photo.CheckSize(800))
            {
                ModelState.AddModelError("Photo", "Image size must be less than 800kb");
                ViewBag.Status = _context.Statuses.ToList();
                ViewBag.Gender = _context.Genders.ToList();
                ViewBag.Department = _context.Departments.ToList();
                return View(employeeUser);
            }
            if (!employeeUser.Photo.CheckType())
            {
                ModelState.AddModelError("Photo", "Type of file must be an image");
                ViewBag.Status = _context.Statuses.ToList();
                ViewBag.Gender = _context.Genders.ToList();
                ViewBag.Department = _context.Departments.ToList();
                return View(employeeUser);
            }
            string userName = string.Empty;
            for (int i= 0 ; i < employeeUser.FullName.Length; i++)
            {
                if (Char.IsWhiteSpace(employeeUser.FullName[i]))
                {
                    continue;
                }
                userName += employeeUser.FullName[i];
            }

            EmployeeUser newEmployee = new EmployeeUser
            {
                FullName = employeeUser.FullName,
                UserName = userName,
                Email = employeeUser.Email,
                BirthDate = employeeUser.BirthDate,
                GenderId = employeeUser.GenderId,
                Gender = employeeUser.Gender,
                StatusId = employeeUser.StatusId,
                Status = employeeUser.Status,
                DepartmentId = employeeUser.DepartmentId,
                Department = employeeUser.Department,
                PhoneNumber = employeeUser.PhoneNumber,
                IdSerialNo = employeeUser.SerialNo,
                FIN = employeeUser.FIN,
                Salary = employeeUser.Salary,
                IsHead = employeeUser.IsHead,
                ProfilePhoto = await employeeUser.Photo.SaveFileAsync(_env.WebRootPath, "assets", "images", "userPhotos"),
                JoinDate = DateTime.Now
            };
            if (_context.Users.Any(user => user.IsHead && employeeUser.IsHead && user.DepartmentId == employeeUser.DepartmentId))
            {
                ModelState.AddModelError("IsHead", "Ther can be only one Head in each Department!");
                ViewBag.Status = _context.Statuses.ToList();
                ViewBag.Gender = _context.Genders.ToList();
                ViewBag.Department = _context.Departments.ToList();
                return View(employeeUser);
            }
            var identityResult = await _userManager.CreateAsync(newEmployee, employeeUser.Password);
            if (!identityResult.Succeeded)
            {
                foreach (var error in identityResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                ViewBag.Status = _context.Statuses.ToList();
                ViewBag.Gender = _context.Genders.ToList();
                ViewBag.Department = _context.Departments.ToList();
                return View(employeeUser);
            }

            await _userManager.AddToRoleAsync(newEmployee, "Employee");
            return RedirectToAction("Index");
        }

        public IActionResult CreateHr()
        {
            ViewBag.Status = _context.Statuses.ToList();
            ViewBag.Gender = _context.Genders.ToList();
            ViewBag.Department = _context.Departments.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateHr(CreateHrUserVM employeeUser)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Status = _context.Statuses.ToList();
                ViewBag.Gender = _context.Genders.ToList();
                ViewBag.Department = _context.Departments.ToList();
                return View(employeeUser);
            }
            if (!employeeUser.Photo.CheckSize(800))
            {
                ModelState.AddModelError("Photo", "Image size must be less than 800kb");
                ViewBag.Status = _context.Statuses.ToList();
                ViewBag.Gender = _context.Genders.ToList();
                ViewBag.Department = _context.Departments.ToList();
                return View(employeeUser);
            }
            if (!employeeUser.Photo.CheckType())
            {
                ModelState.AddModelError("Photo", "Type of file must be an image");
                ViewBag.Status = _context.Statuses.ToList();
                ViewBag.Gender = _context.Genders.ToList();
                ViewBag.Department = _context.Departments.ToList();
                return View(employeeUser);
            }
            string userName = string.Empty;
            for (int i = 0; i < employeeUser.FullName.Length; i++)
            {
                if (Char.IsWhiteSpace(employeeUser.FullName[i]))
                {
                    continue;
                }
                userName += employeeUser.FullName[i];
            }

            EmployeeUser newEmployee = new EmployeeUser
            {
                FullName = employeeUser.FullName,
                UserName = userName,
                Email = employeeUser.Email,
                BirthDate = employeeUser.BirthDate,
                GenderId = employeeUser.GenderId,
                Gender = employeeUser.Gender,
                StatusId = employeeUser.StatusId,
                Status = employeeUser.Status,
                DepartmentId = employeeUser.DepartmentId,
                Department = employeeUser.Department,
                PhoneNumber = employeeUser.PhoneNumber,
                IdSerialNo = employeeUser.SerialNo,
                FIN = employeeUser.FIN,
                Salary = employeeUser.Salary,
                IsHead = employeeUser.IsHead,
                ProfilePhoto = await employeeUser.Photo.SaveFileAsync(_env.WebRootPath, "assets", "images", "userPhotos"),
                JoinDate = DateTime.Now
            };
            if (_context.Users.Any(user => user.IsHead && employeeUser.IsHead && user.DepartmentId == employeeUser.DepartmentId))
            {
                ModelState.AddModelError("IsHead", "Ther can be only one Head in each Department!");
                ViewBag.Status = _context.Statuses.ToList();
                ViewBag.Gender = _context.Genders.ToList();
                ViewBag.Department = _context.Departments.ToList();
                return View(employeeUser);
            }
            var identityResult = await _userManager.CreateAsync(newEmployee, employeeUser.Password);
            if (!identityResult.Succeeded)
            {
                foreach (var error in identityResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                ViewBag.Status = _context.Statuses.ToList();
                ViewBag.Gender = _context.Genders.ToList();
                ViewBag.Department = _context.Departments.ToList();
                return View(employeeUser);
            }

            await _userManager.AddToRoleAsync(newEmployee, "HR Admin");
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(string id)
        {
            ViewBag.Status = _context.Statuses.ToList();
            ViewBag.Gender = _context.Genders.ToList();
            ViewBag.Department = _context.Departments.ToList();
            if(id == null)
            {
                return BadRequest();
            }
            var employeeDb = await _userManager.FindByIdAsync(id);
            if(employeeDb == null)
            {
                return NotFound();
            }
            //EmployeeUser employeeUser = new EmployeeUser
            //{
            //    FullName = employee.UserName,
            //    Email = employee.Email,
            //    PhoneNumber = employee.PhoneNumber,
            //    BirthDate = employee.BirthDate,
            //    GenderId = employee.GenderId,
            //    Gender = employee.Gender,
            //    Status = employee.Status,
            //    StatusId = employee.StatusId,
            //    Department = employee.Department,
            //    DepartmentId = employee.DepartmentId,
            //    IdSerialNo = employee.IdSerialNo,
            //    IsHead = employee.IsHead,
            //    FIN = employee.FIN,
            //    Salary = employee.Salary,
            //    ProfilePhoto = employee.ProfilePhoto
            //};
            return View(employeeDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(EmployeeUser employeeUser)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Status = _context.Statuses.ToList();
                ViewBag.Gender = _context.Genders.ToList();
                ViewBag.Department = _context.Departments.ToList();
                return View(employeeUser);
            }
            EmployeeUser employeeDb = await _context.Users.FindAsync(employeeUser.Id);
            if(employeeDb == null)
            {
                return NotFound();
            }
            if (_context.Users.Any(user => user.IsHead && employeeUser.IsHead && user.DepartmentId == employeeUser.DepartmentId))
            {
                ModelState.AddModelError("IsHead", "Ther can be only one Head in each Department!");
                ViewBag.Status = _context.Statuses.ToList();
                ViewBag.Gender = _context.Genders.ToList();
                ViewBag.Department = _context.Departments.ToList();
                return View(employeeUser);
            }
            string userName = string.Empty;
            for (int i = 0; i < employeeUser.FullName.Length; i++)
            {
                if (Char.IsWhiteSpace(employeeUser.FullName[i]))
                {
                    continue;
                }
                userName += employeeUser.FullName[i];
            }

            employeeDb.FullName = employeeUser.FullName;
            employeeDb.UserName = userName;
            employeeDb.Email = employeeUser.Email;
            //employeeDb.NormalizedEmail = employeeUser.Email.ToUpper();
            employeeDb.BirthDate = employeeUser.BirthDate;
            employeeDb.PhoneNumber = employeeUser.PhoneNumber;
            employeeDb.IdSerialNo = employeeUser.IdSerialNo;
            employeeDb.FIN = employeeUser.FIN;
            employeeDb.GenderId = employeeUser.GenderId;
            employeeDb.Gender = employeeUser.Gender;
            employeeDb.StatusId = employeeUser.StatusId;
            employeeDb.Status = employeeUser.Status;
            employeeDb.DepartmentId = employeeUser.DepartmentId;
            employeeDb.Department = employeeUser.Department;
            employeeDb.IsHead = employeeUser.IsHead;
            employeeDb.Salary = employeeUser.Salary;
            if(employeeDb.Photo != null)
            {
                employeeDb.ProfilePhoto = await employeeUser.Photo.SaveFileAsync(_env.WebRootPath, "assets", "images", "userPhotos");
            }
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Warn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Warn(string id , Warning warning)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var empDb = await _userManager.FindByIdAsync(id);
            if(empDb == null)
            {
                return NotFound();
            }
            Warning newWarning = new Warning
            {
                Message = warning.Message,
                WarningDate = DateTime.Now,
                EmployeeId = empDb.Id,
                Employee = empDb
            };
            await _context.Warnings.AddAsync(newWarning);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Warning");
        }

        public async Task<IActionResult> Quit(string id)
        {
            ViewBag.Status = _context.Statuses.ToList();
            ViewBag.Gender = _context.Genders.ToList();
            ViewBag.Department = _context.Departments.ToList();
            var employee = await _userManager.FindByIdAsync(id);
            employee.IsQuitted = true;
            employee.IsHead = false;
            employee.QuitDate = DateTime.UtcNow;
            await _userManager.UpdateAsync(employee);
            return RedirectToAction("Index");
        }
    }
}
