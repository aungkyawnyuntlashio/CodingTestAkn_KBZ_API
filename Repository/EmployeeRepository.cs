using CodingTestAkn_KBZ_API.DBContexts;
using CodingTestAkn_KBZ_API.Model;
using Microsoft.EntityFrameworkCore;

namespace CodingTestAkn_KBZ_API.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DB_Contexts _dbContext;

        public EmployeeRepository(DB_Contexts dbContext)
        {
            _dbContext = dbContext;
        }

        public void DeleteEmployee(int employeeId)
        {
            var employee = _dbContext.Employees.Find(employeeId);
            _dbContext.Employees.Remove(employee);
            Save();
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            return _dbContext.Employees.ToList();
        }

        public Employee GetEmployeeByID(int employeeId)
        {
            return _dbContext.Employees.Find(employeeId);
        }

        public void InsertEmployee(Employee employee)
        {
            _dbContext.Add(employee);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateEmployee(Employee employee)
        {
            _dbContext.Entry(employee).State = EntityState.Modified;
            Save();
        }
    }
}
