using IdealTimeTracker.API.Models;

namespace IdealTImeTracker.API.Interfaces
{
    public interface IAllUserRepo
    {
        public Task<List<User>> GetAll();
        public Task<List<User>> ChangeReportingForManager(string managerId);
        public Task<User> ChangeReportingForEmployee(string employeeId);


    }
}
