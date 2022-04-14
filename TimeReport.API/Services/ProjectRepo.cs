using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeReport.API.Model;

namespace TimeReport.API.Services
{
    public class ProjectRepo : ITimeReport<Project>
    {
        private readonly AppDbContext _context;

        public ProjectRepo(AppDbContext Context)
        {
            _context = Context;
        }
        public async Task<Project> Add(Project newEntity)
        {
            var result = await _context.Projects.AddAsync(newEntity);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Project> Delete(int id)
        {
            var Delete = await _context.Projects.FirstOrDefaultAsync(p => p.ProjectId == id);
            if (Delete != null)
            {
                var result = _context.Projects.Remove(Delete);
                await _context.SaveChangesAsync();
                return result.Entity;
            }
            return null;
        }

        public Task<int> EmployeeReportWeekly(int id, int year, int week)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Project>> EmployeesProject(int id)
        {
            var result = await _context.Projects.FirstOrDefaultAsync(p => p.ProjectId == id);
            if (result != null)
            {
                return await _context.Projects.Include(i => i.TimeReports).ThenInclude(s => s.Employee)
                    .Where(p => p.ProjectId == id).Distinct().ToListAsync();
            }
            return null;
        }

        public Task<Project> EmployeeWorkedTime(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Project>> GetAll()
        {
            return await _context.Projects.ToListAsync();
        }

        public async Task<Project> GetSingle(int id)
        {
            return await _context.Projects.FirstOrDefaultAsync(p => p.ProjectId == id);
        }

        public async Task<Project> Update(Project Entity)
        {
            var Update = await _context.Projects.FirstOrDefaultAsync(p => p.ProjectId == Entity.ProjectId);
            if (Update != null)
            {
                Update.ProjectName = Entity.ProjectName;

                await _context.SaveChangesAsync();
                return Update;
            }
            return null;
        }
    }
}
