using CodingTestAkn_KBZ_API.Model;
using CodingTestAkn_KBZ_API.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CodingTestAkn_KBZ_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository errorRepository) => _employeeRepository = errorRepository;

        // GET: api/<EmployeeController>
        [HttpGet]
        public IActionResult Get()
        {
            var employees = _employeeRepository.GetAllEmployee();
            return new OkObjectResult(employees);
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var employees = _employeeRepository.GetEmployeeByID(id);
            return new OkObjectResult(employees);
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public IActionResult Post([FromBody] Employee employee)
        {
            using (var scope = new TransactionScope())
            {
                _employeeRepository.InsertEmployee(employee);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = employee.Id }, employee);
            }
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Employee employee)
        {
            if (employee != null)
            {
                using (var scope = new TransactionScope())
                {
                    _employeeRepository.UpdateEmployee(employee);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _employeeRepository.DeleteEmployee(id);
            return new OkResult();
        }
    }
}
