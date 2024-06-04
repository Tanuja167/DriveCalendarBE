using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DriveCalendarBE.Entities
{
    [Table("Roles")]
    public class Roles
    {
        [Key]
        public int RoleId { get; set; }
        public string? RoleName { get; set; }
    }
}
