using DriveCalendarBE.Entities;

namespace DriveCalendarBE.Repository.Interfaces
{
    public interface IDriveStatusRepository
    {
        IEnumerable<DriveStatus> GetAllStatus();
    }
}
