namespace DriveCalendarBE.Entities.DTO
{
    public class UserDto
    {

        public string? UserName { set; get; }
        public string? StudentName { set; get; }
        //public int StudentId { set; get; }
        public string? BatchName { get; set; }
        //public String? Rating { get; set; }
        public int UserId { get; set; }
        public int StudentModeId { set; get; }
        public string? EmailId { get; set; }
        public int RoleId { get; set; }
        public int IsActive { get; set; }
        public int BatchId { get; set; }
        public int StudentId { get; set; }

        public string? StudentModeName { get; set; }

        // public string StudentName { set; get; }


        public string? Ratings { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }

        //Vidyashree Hipparagi 23/12/2023
        public string? MobileNo { get; set; } 
        public string? AlternateMobileNo { get; set; }



    }

}

