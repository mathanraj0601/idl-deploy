namespace IdealTImeTracker.API.Models.DTOs.Userlog
{
    public class UserLogFilterResponseDTO
    {
        public DateTime Date { get; set; }
        public string EmpId { get; set; }
        public string EmpName { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public TimeSpan WorkingHours { get; set; }
        public TimeSpan BreakHours { get; set; }
        public List<UserLogBreakDTO> Breaks { get; set; }
        public int TotalPages { get; set; }
        public int NoOfBreak { get { return Breaks.Count(); } }

    }
}
