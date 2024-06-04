using System.ComponentModel.DataAnnotations.Schema;

namespace DriveCalendarBE.Entities
{
    [Table("tblStudentDrive")]
    public class StudentDrive
    {
        public int StudentDriveId { get; set; }
        public int StudentId { get; set; }
        public int DriveId { get; set; }
        public int StatusId { get; set; }
        public int IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
    }
}
