using DriveCalendarBE.Entities;
using DriveCalendarBE.Repository.Interfaces;

namespace DriveCalendarBE.Repository
{
    public class DriveStatusRepository : IDriveStatusRepository
    {
        private readonly ApplicationDbContext _context;
        public DriveStatusRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<DriveStatus> GetAllStatus()
        {
            return _context.DriveStatus.ToList();
        }
    }
}
