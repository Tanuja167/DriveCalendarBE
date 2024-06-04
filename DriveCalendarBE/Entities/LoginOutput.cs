namespace DriveCalendarBE.Entities
{
    public class LoginOutput
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public string? UserName { get; set; }
        public string? Token { get; set; }
    }
}
