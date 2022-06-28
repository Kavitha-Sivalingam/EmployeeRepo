using System.Collections.Generic;
using EFCoreCodeFirstSample.Models;
using EFCoreCodeFirstSample.Models.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreCodeFirstSample.Controllers 
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IDataRepository<Employee> _dataRepository;
        public EmployeeController(IDataRepository<Employee> dataRepository)
        {
            _dataRepository = dataRepository;
        }
        // GET: api/Employee
        [HttpGet]
        //[Route("/emp")]
        public IActionResult Get()
        {
            IEnumerable<Employee> employees = _dataRepository.GetAll();
            return Ok(employees);
        }
        // GET: api/Employee/2
        [HttpGet("{id}", Name = "Get")]
        public  async Task<IActionResult> Get(long id)
        {
            var employee =  await _dataRepository.Get(id);
            if (employee == null)
            {
                return NotFound("The Employee record couldn't be found.");
            }
            return Ok(employee);
        }
        // POST: api/Employee
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Employee employee)
        {
            if (employee == null)
            {
                return BadRequest("Employee is null.");
            }
             await _dataRepository.Add(employee);
            return NoContent();
            //return CreatedAtRoute(
            //      "Get",
            //      new { Id = employee.EmployeeId },
            //      employee);
        }
        // PUT: api/Employee/2
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] Employee employeeToUpdate)
            //public IActionResult Put(long id)
        {
            //if (employeeToUpdate == null)
            //{
            //    return BadRequest("Employee is null.");
            //}
            //Employee employeeToUpdate = _dataRepository.Update(employee);

            if (employeeToUpdate == null)
            {
                return NotFound("The Employee record couldn't be found.");
            }
            await _dataRepository.Update(employeeToUpdate);
            return NoContent();
        }
        // DELETE: api/Employee/2
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            //Task<List<Employee>> employee = _dataRepository.Get(id);
            if (id == null)
            {
                return NotFound("The Employee record couldn't be found.");
            }
            await _dataRepository.Delete(id);
            return NoContent();
        }
    }
}
