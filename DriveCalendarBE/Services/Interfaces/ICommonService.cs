using DriveCalendarBE.Entities;

namespace DriveCalendarBE.Services.Interfaces
{
    public interface ICommonService
    {
        IEnumerable<StudentModes> GetAllStudentModes();

        IEnumerable<Roles> GetRoles();
        IEnumerable<Round> GetAllRound();
        IEnumerable<Technology> GetAllTechnology();
    }
}
