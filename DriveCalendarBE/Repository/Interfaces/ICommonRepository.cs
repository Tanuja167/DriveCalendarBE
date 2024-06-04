using DriveCalendarBE.Entities;

namespace DriveCalendarBE.Repository.Interfaces
{
    public interface ICommonRepository
    {
        IEnumerable<StudentModes> GetAllStudentModes();

        IEnumerable<Roles> GetRoles();
        IEnumerable<Round> GetAllRound();
        IEnumerable<Technology> GetAllTechnology();
    }
}
