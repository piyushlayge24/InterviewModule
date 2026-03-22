using Interview_Practice.Domain;
using Interview_Practice.Services;
using Microsoft.AspNetCore.Mvc;

namespace Interview_Practice
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _service;

        public EmployeeController(IEmployeeService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> SaveEmployee(Employee employee)
        {
            var created = await _service.CreateAsync(employee);
            return Ok(created);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, Employee updated)
        {
            var success = await _service.UpdateAsync(id, updated);

            if (!success)
                return BadRequest("Update failed.");

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _service.DeleteAsync(id);

            if (!success)
                return NotFound();

            return NoContent();
        }
    }
}
