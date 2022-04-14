using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimeReport.API.Model;

namespace TimeReport.API.Services
{
    public class EmployeeRepo : ITimeReport<Employee>
    {

        private readonly AppDbContext _context;
        public EmployeeRepo(AppDbContext Context)
        {
            _context = Context;
        }


        public async Task<Employee> Add(Employee newEntity)
        {
            var result = await _context.Employees.AddAsync(newEntity);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Employee> Delete(int id)
        {
            var delete = await _context.Employees.FirstOrDefaultAsync(e => e.EmployeeId == id);
            if (delete != null)
            {
                var result = _context.Employees.Remove(delete);
                await _context.SaveChangesAsync();
                return result.Entity;
            }
            return null;
        }

        public async Task<Employee> EmployeeWorkedTime(int id)
        {
            return await _context.Employees.Include(t => t.TimeReports).FirstOrDefaultAsync(e => e.EmployeeId == id);
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee> GetSingle(int id)
        {
            return await _context.Employees.FirstOrDefaultAsync(e => e.EmployeeId == id);
        }

        public async  Task<Employee> Update(Employee Entity)
        {
            var Update = await _context.Employees.FirstOrDefaultAsync(e => e.EmployeeId == Entity.EmployeeId);
            if (Update != null)
            {
                Update.FirstName = Entity.FirstName;
                Update.LastName = Entity.LastName;
                Update.PhoneNumber = Entity.PhoneNumber;
                Update.Email = Entity.Email;
                await _context.SaveChangesAsync();
                return Update;
            }
            return null;
        }

        public Task<int> EmployeeReportWeekly(int id, int year, int weekNumber)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Employee>> EmployeesProject(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
