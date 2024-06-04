using DriveCalendarBE.Entities;
using DriveCalendarBE.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DriveCalendarBE.Repository
{
    public class UpdateStudentProfileRepository : IUpdateStudentProfileRepository
    {
        //private readonly IUpdateStudentProfile updateStudentProfile;
        private readonly ApplicationDbContext context;

        public UpdateStudentProfileRepository(ApplicationDbContext context)
        {
           this.context = context;
        }
       
        public Student GetStudentById(int StudentId)
        {
            var stud = context.Students.Where(x => x.StudentId == StudentId).FirstOrDefault();
            return stud;
        }
        public int UpdateStudentProfile(Student student)
        {
            int result = 0;
            var stud = context.Students.Where(x => x.StudentId == student.StudentId).FirstOrDefault();
            if (stud != null)
            {
                stud.CreatedDate = DateTime.Now;
              //  stud.UserId = student.UserId;
                //stud.BatchId = student.BatchId;
                //stud.Ratings = student.Ratings;
               
                stud.StudentName = student.StudentName;
                stud.MobileNo = student.MobileNo;
                stud.IsActive = 1;
                result = context.SaveChanges();
            }
            return result;
        }

       

    }
}
