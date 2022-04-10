using System.Collections.Generic;
using System.Threading.Tasks;

namespace TimeReport.API.Services
{
    public class EmployeeRepo : ITimeReport<Employee>
    {
        public Task<Employee> Add(Employee newEntity)
        {
            throw new System.NotImplementedException();
        }

        public Task<Employee> Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> EmployeeReportWeekly(int id, int year, int weekNumber)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Employee>> EmployeesProject(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Employee> EmployeeWorkedTime(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Employee>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<Employee> GetSingle(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Employee> Update(Employee Entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
