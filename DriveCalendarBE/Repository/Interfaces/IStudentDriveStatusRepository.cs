using DriveCalendarBE.Entities;

namespace DriveCalendarBE.Repository.Interfaces
{
    public interface IStudentDriveStatusRepository
    {
        IEnumerable<StudentDriveStatus> GetAllStudentDriveStatus();
    }
}
