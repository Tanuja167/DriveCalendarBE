using DriveCalendarBE.Entities.DTO;

namespace DriveCalendarBE.Services.Interfaces
{
    public interface IDashboardService
    {
        long GetTotalDriveCount();
        long GetTotalStudentCount();
        public Dictionary<string, int> GetSelectedCandidateCountByTechnology();
        //long GetTotalPlacementCount();
        long GetCurrentMonthPlacement();
        long GetTotalStudentShortlisted();
        long GetTotalStudentApplied();
        public Dictionary<string, int> GetRejectedCandidateCountByTechnology();
        long GetAppearedStudentCount();
        long GetNewShortlistedStudentCount();
        IEnumerable<StatusDTO> GetStudentDriveStatusCount();
    }
}
