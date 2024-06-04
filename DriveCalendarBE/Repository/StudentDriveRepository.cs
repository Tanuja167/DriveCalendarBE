using DriveCalendarBE.Entities;
using DriveCalendarBE.Entities.DTO;
using DriveCalendarBE.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace DriveCalendarBE.Repository
{
    public class StudentDriveRepository : IStudentDriveRepository
    {
        private readonly ApplicationDbContext dbContext;
        public StudentDriveRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //public int ApplyToDrive(StudentDrive studentDrive)
        //{
        //    studentDrive.IsActive = 1;
        //    dbContext.StudentDrives.Add(studentDrive);
        //    int result = dbContext.SaveChanges();
        //    return result;
        //}
        public int UpdateStudentDrive(StudentDrive studentDrive)
        {
            studentDrive.IsActive = 1;
            int result = 0;
            var data = dbContext.StudentDrives.Where(x => x.StudentDriveId == studentDrive.StudentDriveId).FirstOrDefault();
            if (data != null)
            {
                data.StudentId = studentDrive.StudentId;
                data.DriveId = studentDrive.DriveId;
                data.StatusId = studentDrive.StatusId;
                result = dbContext.SaveChanges();
            }
            return result;
        }
        //public int DeleteStudentDrive(int id)
        //{
        //    int result = 0;
        //    var data = dbContext.StudentDrives.Where(x => x.Id == id).FirstOrDefault();
        //    if (data != null)
        //    {
        //        data.IsActive = 0;
        //        result = dbContext.SaveChanges();
        //    }
        //    return result;
        //}

        /*Created by Girish Jondhale Delete Student Drive Date-25/11/23*/
        public int DeleteStudentDrive(int id)
         {
            int result = 0;

            try
            {
                var studentDrive = dbContext.StudentDrives.SingleOrDefault(x => x.StudentDriveId == id && x.IsActive == 1);

                if (studentDrive != null)
                {
                    
                    studentDrive.IsActive = 0;

                    var detailsList = dbContext.Details.Where(d => d.studentDriveId == studentDrive.StudentDriveId && d.IsActive == 1);

                    foreach (var detail in detailsList)
                    {
                        detail.IsActive = 0;
                    }

                    result = dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            return result;
        }

        public IEnumerable<StudentDriveOutputDto> GetAllStudentDrives()
        {
            var studentDrives = (
                from tsd in dbContext.StudentDrives
               // join us in dbContext.Users on tsd.StudentId equals us.UserId
                join ts in dbContext.Students on tsd.StudentId equals ts.StudentId
                join bd in dbContext.Batchs on ts.BatchId equals bd.BatchId
                join td in dbContext.Drives on tsd.DriveId equals td.DriveId
                join sds in dbContext.StudentDriveStatus on tsd.StatusId equals sds.StatusId
                //join sdd in dbContext.Details on tsd.StudentDriveId equals sdd.studentDriveId
               

                where tsd.IsActive == 1
                select new StudentDriveOutputDto
                {
                   // Id = sdd.Id,
                   // StudentDriveId = tsd.StudentDriveId,
                    StatusId = tsd.StatusId,
                    StatusName = sds.StatusName,
                 //   StudentName = us.UserName,
                    StudentId = ts.StudentId,
                    BatchId = ts.BatchId,
                    Ratings = ts.Ratings,
                    BatchName = bd.BatchName,
                    CompanyName = td.CompanyName,
                    Location = td.Location,
                   // InterviewMode = sdd.InterviewMode,
                   // CompanyAddress = sdd.CompanyAddress,
                   // Note = sdd.Note,
                  //  RoundId = sdd.RoundId,
                    //DriveDate = sdd.DriveDate,
                    //DriveTime = sdd.DriveTime,
                    //CreatedBy = sdd.CreatedBy,
                    DriveId = td.DriveId,
                  //  IsActive = tsd.IsActive,
                    //UserName = us.UserName
                }).ToList();

            return studentDrives;
        }

        /*Created by Akshata Sabne Add Student Drive and drive schedule  Date-21/11/23*/
        public int AddStudentToDrive(StudentDriveDto DrivDetails)
        {
            var studentDrive = new StudentDrive
            {
                StatusId = DrivDetails.StatusId,
                StudentId = DrivDetails.StudentId,
                DriveId = DrivDetails.DriveId,
                CreatedBy = DrivDetails.CreatedBy,
                CreatedDate = DateTime.Now,
                IsActive = 1
            };
            dbContext.StudentDrives.Add(studentDrive);
            dbContext.SaveChanges();
            var studentDriveDetails = new StudentDriveDetails
            {
                studentDriveId = studentDrive.StudentDriveId,
                RoundId = DrivDetails.RoundId,
                CompanyAddress = DrivDetails.CompanyAddress,
                InterviewMode = DrivDetails.InterviewMode,
                Note = DrivDetails.Note,
                DriveDate = DrivDetails.DriveDate,
                DriveTime = DrivDetails.DriveTime,
                CreatedBy = DrivDetails.CreatedBy,
                CreatedDate = DateTime.Now,
                IsActive = 1
            };

            dbContext.Details.Add(studentDriveDetails);
            int result = dbContext.SaveChanges();
            return result;
        }

        //Created by Anjali Buddhe Update Student Drive and drive schedule  Date-22/11/23
        public int UpdateStudentToDrive(StudentDriveDto DrivDetails)
            {
                
                int result = 0;
                 DateTime createdDate = DateTime.Now;
                 var studentDrive = dbContext.StudentDrives
                    .FirstOrDefault(x => x.StudentDriveId == DrivDetails.StudentDeiveDetailsId && x.IsActive == 1);

                if (studentDrive != null)
                {
                // Update StudentDrive
                    studentDrive.StudentId = DrivDetails.StudentId;
                    studentDrive.DriveId = DrivDetails.DriveId;
                    studentDrive.StatusId = DrivDetails.StatusId;
                    studentDrive.CreatedDate = createdDate;
                    studentDrive.CreatedBy = DrivDetails.CreatedBy;

                // Update or add StudentDriveDetails
                var studentDriveDetails = dbContext.Details
                        .FirstOrDefault(d => d.studentDriveId == studentDrive.StudentDriveId && d.IsActive == 1);

                    if (studentDriveDetails != null)
                    {
                        studentDriveDetails.RoundId = DrivDetails.RoundId;
                    
                        studentDriveDetails.CompanyAddress = DrivDetails.CompanyAddress;
                        studentDriveDetails.InterviewMode = DrivDetails.InterviewMode;
                        studentDriveDetails.Note = DrivDetails.Note;
                        studentDriveDetails.DriveDate = DrivDetails.DriveDate;
                        studentDriveDetails.DriveTime = DrivDetails.DriveTime;
                        studentDriveDetails.CreatedDate = createdDate;
                        studentDriveDetails.CreatedBy = DrivDetails.CreatedBy;

                     }
                    result = dbContext.SaveChanges();
                }
                return result;
            }

        //Vidyashree hipparagi search drive fromdate to ToDate 01/12/2023
        

        public IEnumerable<StudentDriveOutputDto> GetStudentDrivesByDateRange(DateTime startDate, DateTime endDate)
        {
            var studentDrives = (
                from tsd in dbContext.StudentDrives
                join us in dbContext.Users on tsd.StudentId equals us.UserId
                join ts in dbContext.Students on tsd.StudentId equals ts.UserId
                join bd in dbContext.Batchs on ts.BatchId equals bd.BatchId
                join td in dbContext.Drives on tsd.DriveId equals td.DriveId
                join sds in dbContext.StudentDriveStatus on tsd.StatusId equals sds.StatusId
                join sdd in dbContext.Details on tsd.StudentDriveId equals sdd.StudentDeiveDetailsId

                where tsd.IsActive == 1 && sdd.IsActive == 1 && sdd.DriveDate >= startDate && sdd.DriveDate <= endDate
                select new StudentDriveOutputDto
                {

                    StudentDriveId = sdd.studentDriveId,
                    StatusId = tsd.StatusId,
                    StatusName = sds.StatusName,
                    StudentName = us.UserName,
                    UserId = ts.StudentId,
                    BatchId = ts.BatchId,
                    Ratings = ts.Ratings,
                    BatchName = bd.BatchName,
                    CompanyName = td.CompanyName,
                    Location = td.Location,
                    InterviewMode = sdd.InterviewMode,
                    CompanyAddress = sdd.CompanyAddress,
                    Note = sdd.Note,
                    RoundId = sdd.RoundId,
                    DriveDate = sdd.DriveDate,
                    DriveTime = sdd.DriveTime,
                    CreatedBy = sdd.CreatedBy,
                    DriveId = td.DriveId,
                    IsActive = tsd.IsActive
                }).ToList();

            return studentDrives;
        }


    }

}


