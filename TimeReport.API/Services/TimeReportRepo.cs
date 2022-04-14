using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimeReport.API.Model;
using System.Linq;

namespace TimeReport.API.Services
{
    public class TimeReportRepo : ITimeReport<TimeReport>
    {
        private readonly AppDbContext _context;

        public TimeReportRepo(AppDbContext Context)
        {
            _context = Context;
        }

        public async Task<TimeReport> Add(TimeReport newEntity)
        {
            var result = await _context.TimeReports.AddAsync(newEntity);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<TimeReport> Delete(int id)
        {
            var Delete = await _context.TimeReports.FirstOrDefaultAsync(t => t.TimeReportId == id);
            if (Delete != null)
            {
                var result = _context.TimeReports.Remove(Delete);
                await _context.SaveChangesAsync();
                return result.Entity;
            }
            return null;
        }

        public async Task<int> EmployeeReportWeekly(int id, int year, int week)
        {
            var timeReports = await _context.TimeReports.Where(x =>
            x.EmployeeId == id && x.Date.Year == year).ToListAsync();
            return timeReports.Where(w => w.Week == week).Sum(h => h.WorkedHours);


        }

        public Task<IEnumerable<TimeReport>> EmployeesProject(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<TimeReport> EmployeeWorkedTime(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<TimeReport>> GetAll()
        {
            return await _context.TimeReports.ToListAsync();
        }

        public async Task<TimeReport> GetSingle(int id)
        {
            return await _context.TimeReports.FirstOrDefaultAsync(x => x.TimeReportId == id);
        }

        public async Task<TimeReport> Update(TimeReport Entity)
        {
            var Update = await _context.TimeReports.FirstOrDefaultAsync(x => x.TimeReportId == Entity.TimeReportId);
            if (Update != null)
            {
                Update.EmployeeId = Entity.EmployeeId;
                Update.ProjectId = Entity.ProjectId;
                Update.Date = Entity.Date;
                Update.WorkedHours = Entity.WorkedHours;

                await _context.SaveChangesAsync();
                return Update;
            }
            return null;
        }
    }
}
