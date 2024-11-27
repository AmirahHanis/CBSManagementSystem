using Microsoft.EntityFrameworkCore;
using CBSManagementSystem.Models;

namespace CBSManagementSystem.Data
{
    public class CBSManagementContext : DbContext
    {
        public CBSManagementContext(DbContextOptions<CBSManagementContext> options) : base(options) { }

        public DbSet<Donation> Donations { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
