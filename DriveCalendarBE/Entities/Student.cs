using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DriveCalendarBE.Entities
{
    [Table("tblStudent")]
    public class Student
    {
        //changed StudentId to Id and studentName to StudentId
        public int StudentId { get; set; }
        public int UserId { get; set; }
        public int BatchId { get; set; }
        
        public string? Ratings { get; set; }
        public int IsActive { get; set; }
        [Column("createDate")]
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public int StudentModeId { get; set; }
        public string? StudentName { get;  set; }
        [Required]
        public string? MobileNo { get; set; }
        public string? AlternateMobileNo { get;set; }
    }
}
