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
            try
            {
                var employees = _employeeRepository.GetAllEmployee();
                return new OkObjectResult(new { message = "Success", data=employees, error = false });
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(new { message = ex.Message, error = true });
            }
            
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var employees = _employeeRepository.GetEmployeeByID(id);
                return new OkObjectResult(new { message = "Success", data=employees, error = false });
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(new { message = ex.Message, error = true });
            }
            
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public IActionResult Post([FromBody] Employee employee)
        {
            try
            {
                using (var scope = new TransactionScope())
                {
                    _employeeRepository.InsertEmployee(employee);
                    scope.Complete();
                    var result = CreatedAtAction(nameof(Get), new { id = employee.Id }, employee);
                    return new OkObjectResult(new { message="Success",data= result.Value ,error=false});
                }
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(new { message = ex.Message, error = true });
            }
            
        }

        // PUT api/<EmployeeController>
        [HttpPut]
        public IActionResult Put([FromBody] Employee employee)
        {
            try
            {
                if (employee != null)
                {
                    using (var scope = new TransactionScope())
                    {
                        _employeeRepository.UpdateEmployee(employee);
                        scope.Complete();
                        return new OkObjectResult(new { message = "Success", data = employee, error = false });
                    }
                }
                return new NoContentResult();
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(new { message = ex.Message, error = true });
            }            
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _employeeRepository.DeleteEmployee(id);
                return new OkObjectResult(new { message = "Success", error = false });
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(new { message = ex.Message, error = true });
            }
            
        }
    }
}
