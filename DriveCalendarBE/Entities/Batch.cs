using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DriveCalendarBE.Entities
{
    [Table("BatchDetails")]
    public class Batch
    {

     
        public int BatchId { get; set; }
        public string? BatchName { get; set; }
        public int TechnologyId { get; set; }
        [NotMapped]
       public string? TechnologyName { get; set; }
        public int IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }

    }
}
