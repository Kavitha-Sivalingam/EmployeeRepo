using Microsoft.EntityFrameworkCore;

namespace EFCoreCodeFirstSample.Models
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions options)
            : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 1,
                FirstName = "Kavitha",
                LastName = "Sivalingam",
                PhoneNumber = "9884745335"
            }, new Employee
            {
                EmployeeId = 2,
                FirstName = "Naresh",
                LastName = "Sivalingam",
                PhoneNumber = "9884857764"
            });
        }
    }
}
