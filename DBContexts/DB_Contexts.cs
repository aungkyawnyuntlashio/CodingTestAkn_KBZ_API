using CodingTestAkn_KBZ_API.Model;
using Microsoft.EntityFrameworkCore;

namespace CodingTestAkn_KBZ_API.DBContexts
{
    public class DB_Contexts: DbContext
    {
        public DB_Contexts(DbContextOptions<DB_Contexts> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Holiday> Holidays { get; set; }
        public DbSet<Leave> Leaves { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = 1,
                    EmployeeName = "Mg Thein",
                    EmployeeCode = "E-00001",
                    Mobile="09977525810",
                    JoinDate=DateTime.Now,
                    Designation="Web Developer",
                    Department="IT",
                    Address="Mandalay",
                    BasicSalary =600000
                }
                );
        }
    }
}
