using DriveCalendarBE.Entities;
using DriveCalendarBE.Repository.Interfaces;
using DriveCalendarBE.Services.Interfaces;

namespace DriveCalendarBE.Services
{
    public class DriveService : IDriveService
    {
        private readonly IDriveRepository repo;
        public DriveService(IDriveRepository repo)
        {
            this.repo = repo;
        }
        public int AddDrive(Drive drive)
        {
            drive.IsActive = 1;
            return repo.AddDrive(drive);
        }

        public int DeleteDrive(int id)
        {
           return repo.DeleteDrive(id);
        }

        public IEnumerable<DriveDTO> GetAllDrives()
        {
            return repo.GetAllDrives();
        }

        public Drive GetDriveById(int id)
        {
            return repo.GetDriveById(id);
        }

        public int UpdateDrive(Drive drive)
        {
            return repo.UpdateDrive(drive);
        }  
        //Vidyashree Hipparagi 02/11/2023
        public IEnumerable<Drive> SearchDrivesByString(string searchQuery)
        {
            return repo.SearchDrivesByString(searchQuery);
        }
    }
}
