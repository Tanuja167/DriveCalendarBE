using DriveCalendarBE.Entities;
using DriveCalendarBE.Repository.Interfaces;
using DriveCalendarBE.Services.Interfaces;

namespace DriveCalendarBE.Services
{
    public class StudentDriveStatusService : IStudentDriveStatusService
    {
        private readonly IStudentDriveStatusRepository repo;
        public StudentDriveStatusService(IStudentDriveStatusRepository repo)
        {
            this.repo = repo;
        }
        public IEnumerable<StudentDriveStatus> GetAllStudentDriveStatus()
        {
            return repo.GetAllStudentDriveStatus();
        }
    }
}
