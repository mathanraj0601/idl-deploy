namespace IdealTImeTracker.API.Models.DTOs.Userlog
{
    public class GetUserLogFilterDTO
    {
        public string EmpId { get; set; }
        public string EmpName { get; set; }
        public double WorkingHours { get; set; }
        public double BreakHours { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public int PageNumber { get; set; }
        public string ManagerId { get; set; }


    }
}
