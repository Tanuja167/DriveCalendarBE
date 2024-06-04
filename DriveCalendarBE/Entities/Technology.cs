using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DriveCalendarBE.Entities
{
    [Table("Technology")]
    public class Technology
    {

            [Key]
            public int TechnologyId { get; set; }
            public string? TechnologyName { get; set; }
        
    }
}
