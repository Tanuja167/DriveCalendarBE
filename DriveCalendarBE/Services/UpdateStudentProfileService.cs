using DriveCalendarBE.Entities;
using DriveCalendarBE.Repository.Interfaces;
using DriveCalendarBE.Services.Interfaces;

namespace DriveCalendarBE.Services
{
    public class UpdateStudentProfileService : IUpdateStudentProfileService
    {
        private readonly IUpdateStudentProfileRepository repository;

        public UpdateStudentProfileService(IUpdateStudentProfileRepository repository)
        {
            this.repository = repository;
        }

        public Student GetStudentById(int studentId)
        {
            return repository.GetStudentById(studentId);
        }

        public int UpdateStudentProfile(Student student)
        {
            return repository.UpdateStudentProfile(student);
        }
    }
}
