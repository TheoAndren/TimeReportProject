using System.Collections.Generic;
using System.Threading.Tasks;

namespace TimeReport.API.Services
{
    public class ProjectRepo : ITimeReport<Project>
    {
        public Task<Project> Add(Project newEntity)
        {
            throw new System.NotImplementedException();
        }

        public Task<Project> Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> EmployeeReportWeekly(int id, int year, int weekNumber)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Project>> EmployeesProject(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Project> EmployeeWorkedTime(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Project>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<Project> GetSingle(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Project> Update(Project Entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
