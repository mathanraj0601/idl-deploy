namespace IdealTImeTracker.API.Models.DTOs.Userlog
{
    public class UserLogFilterResponsePaginationDTO
    {
        public List<UserLogFilterResponseDTO> logs { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
    }
}
