using DriveCalendarBE.Entities;
using DriveCalendarBE.Repository.Interfaces;

namespace DriveCalendarBE.Repository
{
    public class DriveRepository : IDriveRepository
    {
        private readonly ApplicationDbContext _context;
        public DriveRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public int AddDrive(Drive drive)
        {
            int result = 0;
            drive.DriveStatusId = drive.DriveStatusId;
            //Code  Added
            drive.CreatedDate = DateTime.Now;
            _context.Drives.Add(drive);
            result = _context.SaveChanges();
            return result;
        }

        public int DeleteDrive(int id)
        {
            int result = 0;
            var drive = _context.Drives.Where(x => x.DriveId == id).FirstOrDefault();
            if (drive != null)
            {
                drive.IsActive = 0;
                drive.DriveStatusId = 9;
                result= _context.SaveChanges();
            }
            return result;
        }
        //Vidyashree Hipparagi 02/11/2023
        public IEnumerable<DriveDTO> GetAllDrives()
            {
            var users = _context.Users.Where(x => x.RoleId == 2).ToList();

            IEnumerable<DriveDTO> drives = new List<DriveDTO>();

            drives = (
                from drive in _context.Drives
                join user in _context.Users on drive.DriveBy equals user.UserId
                join drivastatus in _context.DriveStatus on drive.DriveStatusId equals drivastatus.DriveStatusId
                select new DriveDTO
                {
                    DriveId = drive.DriveId,
                    CompanyName = drive.CompanyName,
                    DriveBy = user.UserId,
                    Location = drive.Location,
                    Positions = drive.Positions,
                    Criteria = drive.Criteria,
                    Bond = drive.Bond,
                    Package = drive.Package,
                    SelectionProcess = drive.SelectionProcess,
                    WorkType = drive.WorkType,
                    JobDescription = drive.JobDescription,
                    Result = drive.Result,
                    IsActive = drive.IsActive,
                    DriveStatusId = drive.DriveStatusId,
                    DriveByName = user.UserName,
                    DriveStatus = drivastatus.StatusName,
                    RoleId = user.RoleId,


                }
            ).Where(x => x.IsActive == 1).ToList();
            
            return drives;
        }

        public Drive GetDriveById(int id)
        {
            Drive drive = new Drive();
             drive = _context.Drives.Where(x => x.DriveId == id).FirstOrDefault();
            return drive;
        }

       
        public int UpdateDrive(Drive drive)
        {
            int result = 0;
            //Anjali Buddhe(Added Datetime and Created By)
            DateTime createdDate = DateTime.Now;
            var d = _context.Drives.Where(x => x.DriveId == drive.DriveId).FirstOrDefault();
            if (d != null)
            {
                d.SelectionProcess = drive.SelectionProcess;
                d.Location = drive.Location;
                d.JobDescription = drive.JobDescription;
                d.DriveBy = drive.DriveBy;
                d.Bond = drive.Bond;
                d.CompanyName = drive.CompanyName;
                d.Criteria = drive.Criteria;
                d.Package = drive.Package;
                d.DriveStatusId = drive.DriveStatusId;
                d.WorkType = drive.WorkType;
                d.Result = drive.Result;
                d.Positions = drive.Positions;
                d.CreatedDate = createdDate;
                d.CreatedBy = drive.CreatedBy;
                d.IsActive = 1;
                d.DriveStatusId = drive.DriveStatusId;
                d.DriveByName=drive.DriveByName;
                d.DriveStatus=drive.DriveStatus;
                result = _context.SaveChanges();
            }
            return result;
        }
        //Vidyashree Hipparagi 02/11/2023 
        public IEnumerable<Drive> SearchDrivesByString(string searchQuery)
        {
            IEnumerable<Drive> drives = new List<Drive>();

            drives = (
                from drive in _context.Drives
                join user in _context.Users on drive.DriveBy equals user.UserId
                select new Drive
                {
                    DriveId = drive.DriveId,
                    CompanyName = drive.CompanyName,
                    DriveBy= user.UserId,
                    Location = drive.Location,
                    Positions = drive.Positions,
                    Criteria = drive.Criteria,
                    Bond = drive.Bond,
                    Package = drive.Package,
                    SelectionProcess = drive.SelectionProcess,
                    WorkType = drive.WorkType,
                    JobDescription = drive.JobDescription,
                    Result = drive.Result,
                    IsActive = drive.IsActive,
                    DriveStatusId = drive.DriveStatusId,
                    DriveByName = user.UserName, // Include user properties
                    DriveStatus = drive.DriveStatus, // Include drive properties
                   
               
                }
            ).Where(x => x.IsActive == 1).ToList();

            if (!string.IsNullOrEmpty(searchQuery))
            {
                drives = drives.Where(d =>
                    d.CompanyName?.ToLower().Contains(searchQuery.ToLower()) == true ||
                    d.DriveBy.ToString().ToLower().Contains(searchQuery.ToLower()) ||
                    d.Bond?.ToLower().Contains(searchQuery.ToLower()) == true ||
                    d.Positions.ToString().ToLower().Contains(searchQuery.ToLower()) ||
                    d.DriveStatus?.ToLower().Contains(searchQuery.ToLower()) == true ||
                    d.Location?.ToLower().Contains(searchQuery.ToLower()) == true ||
                    d.Criteria?.ToLower().Contains(searchQuery.ToLower()) == true ||
                    d.JobDescription?.ToLower().Contains(searchQuery.ToLower()) == true ||
                    d.Package?.ToLower().Contains(searchQuery.ToLower()) == true ||
                    d.SelectionProcess?.ToLower().Contains(searchQuery.ToLower()) == true ||
                    d.WorkType?.ToLower().Contains(searchQuery.ToLower()) == true ||
                    d.Result?.ToLower().Contains(searchQuery.ToLower()) == true||
                   d.DriveByName?.ToLower().Contains(searchQuery.ToLower()) == true

                ).ToList();
            }

            return drives;
        }


       

    }
}
