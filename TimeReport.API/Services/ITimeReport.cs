using System.Collections.Generic;
using System.Threading.Tasks;

namespace TimeReport.API.Services
{
    public interface ITimeReport<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Add(T newEntity);
        Task<T> GetSingle(int id);
        Task<T> Delete(int id);
        Task<T> Update(T Entity);
        Task<T> EmployeeWorkedTime(int id);
        Task<IEnumerable<T>> EmployeesProject(int id);
        Task<int> EmployeeReportWeekly(int id, int year, int weekNumber);
    }
}
