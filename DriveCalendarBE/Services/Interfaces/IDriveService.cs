using DriveCalendarBE.Entities;

namespace DriveCalendarBE.Services.Interfaces
{
    public interface IDriveService
    {
        public Drive GetDriveById(int id);
        public int AddDrive(Drive drive);
        public int UpdateDrive(Drive drive);
        public int DeleteDrive(int id);
        //Vidyashree Hipparagi 02/11/2023
        public IEnumerable<DriveDTO> GetAllDrives();
        IEnumerable<Drive> SearchDrivesByString(string searchQuery);


    }
}
