using CodingTestAkn_KBZ_API.Model;
using CodingTestAkn_KBZ_API.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CodingTestAkn_KBZ_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveController : ControllerBase
    {
        private readonly ILeaveRepository  _leaveRepository;
        public LeaveController(ILeaveRepository leaveRepository)
        {
            _leaveRepository = leaveRepository;
        }

        // GET: api/<LeaveController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var leaves = _leaveRepository.GetAllLeave();
                return new OkObjectResult(new { message = "Success", data = leaves, error = false });
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(new { message = ex.Message, error = true });
            }
        }

        // GET api/<LeaveController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var leave = _leaveRepository.GetLeaveByID(id);
                return new OkObjectResult(new {message="Success",data=leave,error = false});
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(new { message = ex.Message, error = true });
            }
        }

        // POST api/<LeaveController>
        [HttpPost]
        public IActionResult Post([FromBody] Leave leave)
        {
            try
            {
                using (var scope=new TransactionScope())
                {
                    _leaveRepository.InsertLeave(leave);
                    scope.Complete();
                    var result = CreatedAtAction(nameof(Get), new { id = leave.Id }, leave);
                    return new OkObjectResult(new { message = "Success", data = result.Value, error = false });
                }
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(new { message = ex.Message, error = true });
            }
        }

        // PUT api/<LeaveController>
        [HttpPut]
        public IActionResult Put(Leave leave)
        {
            try
            {
                using (var scope=new TransactionScope())
                {
                    _leaveRepository.UpdateLeave(leave);
                    scope.Complete();
                    return new OkObjectResult(new {message="Success",data=leave,error = false});
                }
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(new {message=ex.Message,error=true});
            }
        }

        // DELETE api/<LeaveController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _leaveRepository.DeleteLeave(id);
                return new OkObjectResult(new { message = "Success", error = false });
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(new { message = ex.Message, error = true });
            }
        }
    }
}
