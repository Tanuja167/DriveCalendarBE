using DriveCalendarBE.Entities.DTO;
using DriveCalendarBE.Repository.Interfaces;
using DriveCalendarBE.Services.Interfaces;

namespace DriveCalendarBE.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly IDashboardRepository repo;
        public DashboardService(IDashboardRepository repo)
        {
            this.repo = repo;
        }
        public long GetCurrentMonthPlacement() //pending to implement
        {
            throw new NotImplementedException();
        }

        public long GetTotalDriveCount()
        {
            return repo.GetTotalDriveCount();
        }

        

        public long GetTotalStudentApplied()
        {
            return repo.GetTotalStudentApplied();
        }

        public long GetTotalStudentCount()
        {
            return repo.GetTotalStudentCount();
        }

        public long GetTotalStudentShortlisted()
        {
            return repo.GetTotalStudentShortlisted();
        }
        //public long GetTotalRejectedStudents()
        //{
        //    return repo.GetTotalRejectedStudents();
        //}
        public long GetAppearedStudentCount()
        {
            return repo.GetAppearedStudentCount();
        }
        public long GetNewShortlistedStudentCount()
        {
            return repo.GetNewShortlistedStudentCount();
        }

        public IEnumerable<StatusDTO> GetStudentDriveStatusCount()
        {
            return repo.GetStudentDriveStatusCount();
        }

        public Dictionary<string, int> GetSelectedCandidateCountByTechnology()
        {
            return repo.GetSelectedCandidateCountByTechnology();
        }

        public Dictionary<string, int> GetRejectedCandidateCountByTechnology()
        {
            return repo.GetRejectedCandidateCountByTechnology();
        }
    }
}
