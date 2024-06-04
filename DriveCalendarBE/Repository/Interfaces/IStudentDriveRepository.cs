using DriveCalendarBE.Entities;
using DriveCalendarBE.Entities.DTO;

namespace DriveCalendarBE.Repository.Interfaces
{
    public interface IStudentDriveRepository
    {
        //int ApplyToDrive(StudentDrive studentDrive);

        IEnumerable<StudentDriveOutputDto> GetAllStudentDrives();
        int UpdateStudentDrive(StudentDrive studentDrive);
        int DeleteStudentDrive(int id);
        int AddStudentToDrive(StudentDriveDto DrivDetails);
        int UpdateStudentToDrive(StudentDriveDto DrivDetails);
        IEnumerable<StudentDriveOutputDto> GetStudentDrivesByDateRange(DateTime startDate, DateTime endDate);
    }
}
