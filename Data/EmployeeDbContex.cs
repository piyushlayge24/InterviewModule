using Microsoft.EntityFrameworkCore;

namespace Interview_Practice.Domain
{
    public class EmployeeDbcontex : DbContext
    {
        public EmployeeDbcontex(DbContextOptions<EmployeeDbcontex> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
    }
}
