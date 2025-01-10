using Microsoft.EntityFrameworkCore;
using WebApplication15.Models;

namespace WebApplication15.Data
{
    // Parent Class
    public class WebApplication15DbContext:DbContext
    {
        // Constructor
        //                                                                           <>
        public WebApplication15DbContext(DbContextOptions<WebApplication15DbContext> options):base(options)
        {
        }

        // Entity
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}
