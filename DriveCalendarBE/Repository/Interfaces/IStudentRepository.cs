using DriveCalendarBE.Entities;
using DriveCalendarBE.Entities.DTO;

namespace DriveCalendarBE.Repository.Interfaces
{
    public interface IStudentRepository
    {
        IEnumerable<StudentDtetailsDto> GetAllStudents();
        Student GetStudentById(int StudentId);
        int AddStudent(Student student);
        int UpdateStudent(Student student);
        //int DeleteStudent(int StudentId);
        int DeleteStudent(int StudentId);
        IEnumerable<StudentDtetailsDto> GetStudents();
        Student GetStudentByUserId(int UserId);

        int UpdateUsers(Student student);

    }
}
