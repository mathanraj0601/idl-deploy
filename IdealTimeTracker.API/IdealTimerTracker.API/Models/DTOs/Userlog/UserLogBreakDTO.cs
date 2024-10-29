namespace IdealTImeTracker.API.Models.DTOs.Userlog
{
    public class UserLogBreakDTO
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public TimeSpan Duration { get; set; }
        public string Reason { get; set; }

    }
}
