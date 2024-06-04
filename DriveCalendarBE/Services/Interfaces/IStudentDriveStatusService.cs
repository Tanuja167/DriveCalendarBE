using DriveCalendarBE.Entities;

namespace DriveCalendarBE.Services.Interfaces
{
    public interface IStudentDriveStatusService
    {
        IEnumerable<StudentDriveStatus> GetAllStudentDriveStatus();
    }
}
