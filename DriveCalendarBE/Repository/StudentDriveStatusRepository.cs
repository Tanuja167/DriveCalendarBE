using DriveCalendarBE.Entities;
using DriveCalendarBE.Repository.Interfaces;

namespace DriveCalendarBE.Repository
{
    public class StudentDriveStatusRepository : IStudentDriveStatusRepository
    {
        private readonly ApplicationDbContext dbContext;
        public StudentDriveStatusRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IEnumerable<StudentDriveStatus> GetAllStudentDriveStatus()
        {
            return dbContext.StudentDriveStatus.ToList();
        }
    }
}
