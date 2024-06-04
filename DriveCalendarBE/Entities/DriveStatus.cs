using System.ComponentModel.DataAnnotations.Schema;

namespace DriveCalendarBE.Entities
{
    [Table("DriveStatus")]
    public class DriveStatus
    {
        public int DriveStatusId { get; set; }
        public string? StatusName { get; set; }
    }
}
