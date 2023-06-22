using Employee_management_system.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Employee_management_system.Context
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {


        }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }

    }
}
