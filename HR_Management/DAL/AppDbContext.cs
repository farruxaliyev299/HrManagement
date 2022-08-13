using HR_Management.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HR_Management.DAL
{
    public class AppDbContext: IdentityDbContext<EmployeeUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
        }

        public DbSet<Holiday> Holidays { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectEmployee> ProjectEmployees { get; set; }
        public DbSet<Leave> Leaves { get; set; }
    }
}
