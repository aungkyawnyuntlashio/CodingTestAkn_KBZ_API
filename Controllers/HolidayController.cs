using CodingTestAkn_KBZ_API.Model;
using CodingTestAkn_KBZ_API.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CodingTestAkn_KBZ_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HolidayController : ControllerBase
    {
        private readonly IHolidayRepository _holidayRepository;
        public HolidayController(IHolidayRepository holidayRepository)
        {
            _holidayRepository = holidayRepository;
        }

        // GET: api/<HolidayController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var result=_holidayRepository.GetAllHoliday();
                return new OkObjectResult(new {message="Success",data=result,error=false});
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(new { message = ex.Message, error = true });
            }
        }

        // GET api/<HolidayController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var result = _holidayRepository.GetHolidayByID(id);
                return new OkObjectResult(new {message="Success",data= result,error=false});
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(new {message=ex.Message,error=true});
            }
        }

        // POST api/<HolidayController>
        [HttpPost]
        public IActionResult Post([FromBody] Holiday holiday)
        {
            try
            {
                using (var scope = new TransactionScope())
                {
                    _holidayRepository.InsertHoliday(holiday);
                    scope.Complete();
                    var result = CreatedAtAction(nameof(Get), new { id = holiday.Id }, holiday);
                    return new OkObjectResult(new { message = "Success", data = result.Value, error = false });
                }
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(new { message = ex.Message, error = true });
            }
        }

        // PUT api/<HolidayController>
        [HttpPut]
        public IActionResult Put(Holiday holiday)
        {
            try
            {
                using (var scope=new TransactionScope())
                {
                    _holidayRepository.UpdateHoliday(holiday);
                    scope.Complete();
                    return new OkObjectResult(new { message = "Success", data = holiday, error = false });
                }
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(new { message = ex.Message, error = true });
            }
        }

        // DELETE api/<HolidayController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _holidayRepository.DeleteHoliday(id);
                return new OkObjectResult(new {message="Success",error=false});
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(new {message=ex.Message,error=true});
            }
        }
    }
}
