using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TimeReport.API.Services;

namespace TimeReport.API.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
        public class EmployeeController : ControllerBase
        {
            private readonly ITimeReport<Employee> _timeProject;

            public EmployeeController(ITimeReport<Employee> timeProject)
            {
                _timeProject = timeProject;
            }
            [HttpGet]
            public async Task<ActionResult> GetAllEmployees()
            {
                try
                {
                    return Ok(await _timeProject.GetAll());

                }
                catch (Exception)
                {

                    return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from database");
                }
            }

            [HttpGet("{id:int}")]
            public async Task<ActionResult<Employee>> GetEmployee(int id)
            {
                try
                {
                    var result = await _timeProject.GetSingle(id);
                    if (result == null)
                    {
                        return NotFound();
                    }
                    return result;
                }
                catch (Exception)
                {

                    return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from database");
                }
            }

            [HttpGet("time/{id}")]
            public async Task<ActionResult<Employee>> GetEmployeeHoursWorked(int id)
            {
                try
                {
                    var result = await _timeProject.EmployeeWorkedTime(id);
                    if (result == null)
                    {
                        return NotFound();
                    }
                    return result;
                }
                catch (Exception)
                {

                    return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from database");
                }
            }

            [HttpPost]
            public async Task<ActionResult<Employee>> CreateNewEmployee(Employee newEmployee)
            {
                try
                {
                    if (newEmployee == null)
                    {
                        return BadRequest();
                    }
                    var createdEmployee = await _timeProject.Add(newEmployee);
                    return CreatedAtAction(nameof(GetEmployee), new { id = createdEmployee.EmployeeId }, createdEmployee);
                }
                catch (Exception)
                {

                    return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from database");
                }
            }

            [HttpDelete("{id}")]
            public async Task<ActionResult<Employee>> DeleteEmployee(int id)
            {
                try
                {
                    var Delete = await _timeProject.Delete(id);
                    if (Delete == null)
                    {
                        return NotFound($"Employee with id {id} does not exist");
                    }
                    return NoContent();
                }
                catch (Exception)
                {

                    return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from database");
                }
            }

            [HttpPut("{id}")]
            public async Task<ActionResult<Employee>> UpdateEmployee(int id, Employee employee)
            {
                try
                {
                    if (id != employee.EmployeeId)
                    {
                        return BadRequest("Employee id do not match");
                    }
                    var Update = await _timeProject.GetSingle(id);
                    if (Update == null)
                    {
                        return NotFound($"Employee with id {id} does not exist");
                    }
                    return await _timeProject.Update(employee);
                }
                catch (Exception)
                {

                    return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from database");
                }
            }

        }
    }
