using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DriveCalendarBE.Entities
{
    [Table("StudentDriveStatus")]
    public class StudentDriveStatus
    {
        [Key]
        public int StatusId { get; set; }
        public string? StatusName { get; set; }
    }
}
