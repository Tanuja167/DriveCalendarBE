using DriveCalendarBE.Entities;

namespace DriveCalendarBE.Services.Interfaces
{
    public interface IUpdateStudentProfileService
    {
        Student GetStudentById(int studentId);

        int UpdateStudentProfile(Student student);
    }
}
