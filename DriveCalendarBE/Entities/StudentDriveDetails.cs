using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DriveCalendarBE.Entities
{
    [Table("studentDriveDetails")]
    public class StudentDriveDetails
    {
        [Key]
        public int StudentDeiveDetailsId { get; set; }
        [Required]
        public int studentDriveId { get; set; }
        [Required]
        public int RoundId { get; set; }
        [Required]
        public DateTime DriveDate { get; set; }
        [Required]
        public string? DriveTime { get; set; }
        [Required]
        public string? InterviewMode { get; set;}
        [Required]
        public string? CompanyAddress { get; set; }
        [Required]
        public string? Note { get; set; }
        [Required]
        public DateTime? CreatedDate { get; set; }
        [Required]
        public int CreatedBy { get; set; }

        public int IsActive { get; set; }

    }
}
