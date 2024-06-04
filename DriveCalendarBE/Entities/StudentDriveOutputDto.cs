namespace DriveCalendarBE.Entities
{
    public class StudentDriveOutputDto
    {
        public int StudentDriveId { get; set; }
        public int StatusId { get; set; }

        public string? StudentName { get; set; }
        public string? BatchName { get; set; }
        public string? Ratings { get; set; }
        public string? CompanyName { get; set; }
        public string? Location { get; set; }
        public string? StatusName { get; set; }
        public int UserId { get; set; }
        public int DriveId { get; set; }
        public int IsActive { get; set; }
        public int BatchId { get; set; }
        public string? InterviewMode { get; set; }
        public string? CompanyAddress { get; set; }
        public string? Note { get; set; }
        public int RoundId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime DriveDate { get; set; }
        public string? DriveTime { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int StudentId { get; set; }
        public int Id { get; set; }
        public string? roundName { get; set; }
    }
}
