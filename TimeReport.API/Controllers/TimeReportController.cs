using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TimeReport.API.Services;

namespace TimeReport.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeReportController : ControllerBase
    {
        private readonly ITimeReport<TimeReport> _timeProject;
        public TimeReportController(ITimeReport<TimeReport> timeProject)
        {
            _timeProject = timeProject;
        }

        [HttpGet]
        public async Task<ActionResult<TimeReport>> GetAllTimeReports()
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
        public async Task<ActionResult<TimeReport>> GetTimeReport(int id)
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
        public async Task<ActionResult<TimeReport>> CreateTimeReport(TimeReport newTime)
        {
            try
            {
                if (newTime == null)
                {
                    return BadRequest();
                }
                var createdTime = await _timeProject.Add(newTime);
                return CreatedAtAction(nameof(GetTimeReport), new { id = createdTime.TimeReportId }, createdTime);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from database");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TimeReport>> DeleteTimeReport(int id)
        {
            try
            {
                var timeToDelete = await _timeProject.Delete(id);
                if (timeToDelete == null)
                {
                    return NotFound($"Time report with id {id} does not exist");
                }
                return NoContent();
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from database");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TimeReport>> UpdateTimeReport(int id, TimeReport time)
        {
            try
            {
                if (id != time.TimeReportId)
                {
                    return BadRequest("Time report id does dont match");
                }
                var timeToUpdate = await _timeProject.GetSingle(id);
                if (timeToUpdate == null)
                {
                    return NotFound($"Time report with id {id} dosent exist");
                }
                return await _timeProject.Update(time);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from database");
            }
        }

        [HttpGet("{id:int}/year={year:int}/week={week:int}")]
        public async Task<ActionResult<int>> ReportedTimeWeek(int id, int year, int week)
        {
            try
            {
                var result = await _timeProject.EmployeeReportWeekly(id, year, week);
                if (result == 0)
                {
                    return NotFound($"No time reports registered for employee with id {id} for week {week}, {year}");
                }
                return Ok(result);

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from database");
            }
        }
    }
}
