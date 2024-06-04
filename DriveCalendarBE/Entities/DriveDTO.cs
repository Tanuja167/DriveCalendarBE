using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DriveCalendarBE.Entities
{  
    //Vidyashree Hipparagi 02/11/2023

    public class DriveDTO
    {

    
        public int DriveId { get; set; }

        public string? CompanyName { get; set; }

        public int DriveBy { get; set; }
   
        public string? Location { get; set; }
     
        public int Positions { get; set; }
        public string? Criteria { get; set; }
        public string? Bond { get; set; }

        public string? Package { get; set; }
     
        public string? SelectionProcess { get; set; }
      
        public string? WorkType { get; set; }

        public string? JobDescription { get; set; }
        public string? Result { get; set; }
        public int IsActive { get; set; }

        public int DriveStatusId { get; set; }
    
        public string? DriveByName { get; set; }
     
        public string? DriveStatus { get; set; }
        public int RoleId { get; set; }

    }
}
