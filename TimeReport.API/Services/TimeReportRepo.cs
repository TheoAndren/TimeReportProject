using System.Collections.Generic;
using System.Threading.Tasks;

namespace TimeReport.API.Services
{
    public class TimeReportRepo : ITimeReport<TimeReport>
    {
        public Task<TimeReport> Add(TimeReport newEntity)
        {
            throw new System.NotImplementedException();
        }

        public Task<TimeReport> Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> EmployeeReportWeekly(int id, int year, int weekNumber)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<TimeReport>> EmployeesProject(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<TimeReport> EmployeeWorkedTime(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<TimeReport>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<TimeReport> GetSingle(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<TimeReport> Update(TimeReport Entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
