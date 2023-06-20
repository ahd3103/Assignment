using EF_Code_FirstApproach.Model;
using Microsoft.EntityFrameworkCore;

namespace EF_Code_FirstApproach.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {


        }
        public DbSet<Employee> Employees { get; set; }
    }
}
