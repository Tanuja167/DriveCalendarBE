using DriveCalendarBE.Entities;
using DriveCalendarBE.Repository.Interfaces;
using DriveCalendarBE.Services.Interfaces;

namespace DriveCalendarBE.Services
{
    public class DriveStatusService : IDriveStatusService
    {
        private readonly IDriveStatusRepository repo;
        public DriveStatusService(IDriveStatusRepository repo)
        {
            this.repo = repo;
        }
        public IEnumerable<DriveStatus> GetAllStatus()
        {
            return repo.GetAllStatus(); 
        }
    }
}
