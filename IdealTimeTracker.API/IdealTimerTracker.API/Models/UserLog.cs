using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace IdealTimeTracker.API.Models
{
    public class UserLog
    {

        [Key]
        public Guid Id { get; set; }
        public string EmpId { get; set; }
        public User? User { get; set; }

        [ForeignKey("UserActivity")]
        public int? ActivityId { get; set; }
        public string? Reason { get; set; }
        public UserActivity? UserActivity { get; set; }
        public TimeSpan Duration { get; set; }
        public DateTime ActivityAt { get; set; }
        [AllowNull]
        public DateTime? IdealAt { get; set; } = null;
        public DateTime Date { get; set; }

    }
}
