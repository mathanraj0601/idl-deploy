using IdealTImeTracker.API.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace IdealTimeTracker.API.Models
{
    public class UserContext : DbContext
    {
       
        public UserContext(DbContextOptions<UserContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    EmpId = "ADMIN",
                    PassWord = "ADMIN",
                    IsActive = true,
                    Role = "admin",
                    Name = "Admin User",
                    Email = "admin@example.com",
                    ReportingTo = null,
                    modifiedOn = DateTime.Now,
                    createdOn = DateTime.Now,
                },
                new User
                {
                    Id = 2,
                    EmpId = "SUPERMANAGER",
                    PassWord = "SUPERMANAGER",
                    IsActive = true,
                    Role = "manager",
                    Name = "Super manager User",
                    Email = "supermanager@example.com",
                    ReportingTo = null,
                    modifiedOn = DateTime.Now,
                    createdOn = DateTime.Now,

                }
            ); ;

            modelBuilder.Entity<UserActivity>().HasData(
                  //new UserActivity { Id = 1, Activity = "none", DurationInMins = 0, CountPerDay = null, IsActive = true },
                  new UserActivity { Id = 2, Activity = "login", DurationInMins = 0, CountPerDay = null, IsActive = true },
                  new UserActivity { Id = 3, Activity = "logout", DurationInMins = 0, CountPerDay = null, IsActive = true, },
                  new UserActivity { Id = 4, Activity = "Others", DurationInMins = 0, CountPerDay = null, IsActive = true, },
                  new UserActivity { Id = 5, Activity = "ShiftLogin", DurationInMins = 0, CountPerDay = null, IsActive = true, },
                  new UserActivity { Id = 7, Activity = "tea break", DurationInMins = 15, CountPerDay = 2, IsActive = true },
                  new UserActivity { Id = 8, Activity = "lunch break", DurationInMins = 30, CountPerDay = 2, IsActive = true });

            modelBuilder.Entity<ApplicationConfiguration>().HasData(
                new ApplicationConfiguration { Id = 1, Name = "IDEAL TIME", Value = new TimeSpan(0, 5, 0) },
                new ApplicationConfiguration { Id = 2, Name = "WORKING TIME", Value = new TimeSpan(0, 5, 0) },
                new ApplicationConfiguration { Id = 3, Name = "SYNC TIME ONE", Value = new TimeSpan(4, 0, 0) },
                new ApplicationConfiguration { Id = 4, Name = "SYNC TIME TWO", Value = new TimeSpan(13,0, 0) }
            );

        }
        public  virtual DbSet<User>? Users { get; set; }
        public virtual DbSet<ApplicationConfiguration>? ApplicationConfigurations { get; set; }
        public virtual DbSet<UserActivity>? UserActivities { get; set; }
        public virtual DbSet<UserLog>? UserLogs { get; set; }


    }
}
