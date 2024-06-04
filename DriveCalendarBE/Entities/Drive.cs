using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DriveCalendarBE.Entities
{
    [Table("tblDrive")]
    public class Drive
    {
        [Key]
        public int DriveId { get; set; }
        [Required]
        public string? CompanyName { get; set; }
        [Required]
        public int DriveBy { get; set; }
        [Required]
        public string? Location { get; set; }
        [Required]
        public int Positions { get; set; }
        public string? Criteria { get; set; }
        public string? Bond { get; set; }
        [Required]
        public string? Package { get; set; }
        [Required]
        public string? SelectionProcess { get; set; }
        [Required]
        public string? WorkType { get; set; }

        public string? JobDescription { get; set; }
        public string? Result { get; set; }
        public int IsActive { get; set; }

        public int DriveStatusId { get; set; }
        [NotMapped]
        public string? DriveByName { get; set; }
        [NotMapped]
        public string? DriveStatus { get; set; }
        [Column("createDate")]
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }

    }
}
