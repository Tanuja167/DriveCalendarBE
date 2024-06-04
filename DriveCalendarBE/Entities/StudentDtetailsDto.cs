namespace DriveCalendarBE.Entities
{
    public class StudentDtetailsDto
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? EmailId { get; set; }
        public int RoleId { get; set; }

        public int BatchId { get; set; }

        public string BatchName { get; set;}
        public int StudentId { get; set;}


        public string? Ratings { get; set; }
        public string? StudentName{ get; set; }
        public int StudentModelId { get; set; }
        public string Name { get; set; }
       

        public int IsActive { get; set; }

    }
}
