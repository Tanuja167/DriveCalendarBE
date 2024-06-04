using DriveCalendarBE.Entities;
using DriveCalendarBE.Entities.DTO;

namespace DriveCalendarBE.Services.Interfaces
{
    public interface IStudentService
    {
        IEnumerable<StudentDtetailsDto> GetAllStudents();
        Student GetStudentById(int StudentId);
        int AddStudent(Student student);
       
        int DeleteStudent(int StudentId);

        IEnumerable<StudentDtetailsDto> GetStudents();
        Student GetStudentByUserId(int UserId);

        int UpdateUsers(Student student);

    }
}
