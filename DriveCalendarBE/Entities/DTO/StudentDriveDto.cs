using System.ComponentModel.DataAnnotations;

namespace DriveCalendarBE.Entities.DTO
{
    public class StudentDriveDto
    {
        public int StudentDeiveDetailsId { get; set; }
        public int StudentId { get; set; }
        public int StatusId { get; set; }
        public int studentDriveId { get; set; }
        public int RoundId { get; set; }
        public int DriveId { get; set; }
        public string? InterviewMode { get; set; }
        public string? CompanyAddress { get; set; }
        public string? Note { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime DriveDate { get; set; }
        public string? DriveTime { get; set; }
        public int IsActive { get; set; }
        public string? BatchName { get; set; }
        public string? Ratings { get; set; }
        public string? Location { get; set; }
        public string? StatusName { get; set; }
        public string? CompanyName { get; set; }
        public int BatchId { get; set; }


    }
}
