using DriveCalendarBE.Entities;
using DriveCalendarBE.Entities.DTO;
using DriveCalendarBE.Repository.Interfaces;
using DriveCalendarBE.Services.Interfaces;

namespace DriveCalendarBE.Services
{
    public class StudentService : IStudentService
    {
       
        private readonly IStudentRepository repo;
        public StudentService(IStudentRepository repo)
        {
            this.repo = repo;
        }
        public int AddStudent(Student student)
        {
            student.IsActive = 1;
            return repo.AddStudent(student);
        }

        public int DeleteStudent(int StudentId)
        {
            return repo.DeleteStudent(StudentId);
        }

        public IEnumerable<StudentDtetailsDto> GetAllStudents()
        {
            return repo.GetAllStudents();
        }

        public Student GetStudentById(int StudentId)
        {
            return repo.GetStudentById(StudentId);
        }

       
        public IEnumerable<StudentDtetailsDto> GetStudents()
        {
            return repo.GetStudents();
        }
        public Student GetStudentByUserId(int userId)
        {
            return repo.GetStudentByUserId(userId);
        }
        public int UpdateUsers(Student student)
        {
           return repo.UpdateUsers(student);
        }
    }
}
