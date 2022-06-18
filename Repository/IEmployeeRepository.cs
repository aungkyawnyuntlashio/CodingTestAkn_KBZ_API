using CodingTestAkn_KBZ_API.Model;

namespace CodingTestAkn_KBZ_API.Repository
{
    public interface IEmployeeRepository
    {

        IEnumerable<Employee> GetAllEmployee();

        Employee GetEmployeeByID(int employeeId);
        void InsertEmployee(Employee employee);
        void DeleteEmployee(int employeeId);
        void UpdateEmployee(Employee employee);
        void Save();
    }
}
