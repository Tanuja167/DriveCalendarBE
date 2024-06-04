using DriveCalendarBE.Entities.DTO;

namespace DriveCalendarBE.Repository.Interfaces
{
    public interface IDashboardRepository
    {
        long GetTotalDriveCount();
        long GetTotalStudentCount();

        public Dictionary<string, int> GetSelectedCandidateCountByTechnology();

        public Dictionary<string, int> GetRejectedCandidateCountByTechnology();
        //long GetTotalPlacementCount();
        long GetCurrentMonthPlacement();
        long GetTotalStudentShortlisted();
        long GetTotalStudentApplied();
        //long GetTotalRejectedStudents();
        long GetAppearedStudentCount();
        long GetNewShortlistedStudentCount();
        IEnumerable<StatusDTO> GetStudentDriveStatusCount();
    }
}
