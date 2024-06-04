using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DriveCalendarBE.Entities

//  created by - girish jondhale
// created date - 05/11/2023
// description - created student modes class
{
    [Table("StudentModes")]
    public class StudentModes
    {
        [Key]
        public int StudentModeId { get; set; }

        public string? StudentModeName { get; set; }
    }
}
