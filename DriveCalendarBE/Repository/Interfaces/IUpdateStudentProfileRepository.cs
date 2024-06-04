using DriveCalendarBE.Entities;

namespace DriveCalendarBE.Repository.Interfaces
{
    public interface IUpdateStudentProfileRepository
    {
        Student GetStudentById(int studentId);

        int UpdateStudentProfile(Student student);
    }
}
