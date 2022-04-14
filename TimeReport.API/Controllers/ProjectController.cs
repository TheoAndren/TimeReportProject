using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TimeReport.API.Services;

namespace TimeReport.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly ITimeReport<Project> _timeProject;

        public ProjectController(ITimeReport<Project> timeProject)
        {
            _timeProject = timeProject;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllProjects()
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
        public async Task<ActionResult<Project>> GetProject(int id)
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

        [HttpPost]
        public async Task<ActionResult<Project>> CreateNewProject(Project newProject)
        {
            try
            {
                if (newProject == null)
                {
                    return BadRequest();
                }
                var createdProject = await _timeProject.Add(newProject);
                return CreatedAtAction(nameof(GetProject), new { id = createdProject.ProjectId }, createdProject);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from database");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProject(int id)
        {
            try
            {
                var Delete = await _timeProject.Delete(id);
                if (Delete == null)
                {
                    return NotFound($"Project with id {id} does not exist");
                }
                return NoContent();
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from database");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Project>> UpdateProject(int id, Project project)
        {
            try
            {
                if (id != project.ProjectId)
                {
                    return BadRequest("No match for project id");
                }
                var Update = await _timeProject.GetSingle(id);
                if (Update == null)
                {
                    return NotFound($"Project with id {id} does not exist");
                }
                return await _timeProject.Update(project);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from database");
            }
        }

        [HttpGet("{id}/employees")]
        public async Task<ActionResult<Project>> GetProjectEmployees(int id)
        {
            try
            {
                var result = await _timeProject.EmployeesProject(id);
                if (result != null)
                {
                    return Ok(result);
                }
                return NotFound();
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from database");
            }
        }
    }
}
