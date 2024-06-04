using DriveCalendarBE.Entities;

namespace DriveCalendarBE.Services.Interfaces
{
    public interface IDriveStatusService
    {
        IEnumerable<DriveStatus> GetAllStatus();
    }
}
