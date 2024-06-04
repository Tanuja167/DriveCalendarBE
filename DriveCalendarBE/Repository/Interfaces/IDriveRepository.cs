using DriveCalendarBE.Entities;

namespace DriveCalendarBE.Repository.Interfaces
{
    public interface IDriveRepository
    {
         //IEnumerable<Drive> GetAllDrives(string co);
         Drive GetDriveById(int id);
         int AddDrive(Drive drive);
         int UpdateDrive(Drive drive);
         int DeleteDrive(int id);
        //Vidyashree Hipparagi 02/11/2023
        IEnumerable<DriveDTO> GetAllDrives();

        IEnumerable<Drive> SearchDrivesByString(string searchQuery);
    }
}
