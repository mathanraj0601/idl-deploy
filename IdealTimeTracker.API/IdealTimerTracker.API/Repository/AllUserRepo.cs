using IdealTimeTracker.API.Exceptions;
using IdealTimeTracker.API.Models;
using IdealTImeTracker.API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IdealTImeTracker.API.Repository   
{
    public class AllUserRepo : IAllUserRepo
    {
        private readonly UserContext _userContext;
        public AllUserRepo(UserContext userContext)
        {
            _userContext = userContext;
        }

        public async Task<User> ChangeReportingForEmployee(string employeeId)
        {
            if (_userContext.Users == null)
                throw new ContextException("User context is Empty");
            var user = _userContext.Users.FirstOrDefault(user => user.EmpId == employeeId && user.IsActive);
            user.ReportingTo = "SUPERMANAGER";
            await _userContext.SaveChangesAsync();
            return user;
        }

        public async Task<List<User>> ChangeReportingForManager(string managerId)
        {
            if (_userContext.Users == null)
                throw new ContextException("User context is Empty");
            var users = _userContext.Users.Where(user => user.ReportingTo == managerId && user.IsActive).ToList();
            foreach (var user in users)
            {
                user.ReportingTo = "SUPERMANAGER"; // Update the ManagerId or any other reporting structure
            }
            await _userContext.SaveChangesAsync();
            return users.ToList();
        }

        public async Task<List<User>> GetAll()
        {
            

            if (_userContext.Users == null)
                throw new ContextException("User context is Empty");
            var users = await _userContext.Users
                                .ToListAsync(); // Example filtering condition
            if (users == null)
                throw new UserException("User not found");
            return users;

        }
    }
}
