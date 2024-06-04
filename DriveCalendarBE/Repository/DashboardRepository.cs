using DriveCalendarBE.Entities;
using DriveCalendarBE.Entities.DTO;
using DriveCalendarBE.Repository.Interfaces;

namespace DriveCalendarBE.Repository
{
    public class DashboardRepository : IDashboardRepository
    {
        private ApplicationDbContext context;
        public DashboardRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public long GetCurrentMonthPlacement() //pending to implement
        {
            throw new NotImplementedException();
        }

        public long GetTotalDriveCount()
        {
            var result= context.Drives.Count();
            return result;
        }

        public Dictionary<string, int> GetSelectedCandidateCountByTechnology()
        {
            var query = from b in context.Batchs
                        join t in context.technologies on b.TechnologyId equals t.TechnologyId
                        join s in context.Students on b.BatchId equals s.BatchId
                        join sd in context.StudentDrives on s.StudentId equals sd.StudentId
                        where sd.StatusId == 4
                        group sd.StatusId by new { sd.StatusId, b.TechnologyId, t.TechnologyName } into grouped
                        select new
                        {
                            TechnologyName = grouped.Key.TechnologyName,
                            SelectedCandidateCount = grouped.Count()
                        };

            return query.ToDictionary(x => x.TechnologyName, x => x.SelectedCandidateCount);
        }


        public long GetTotalStudentApplied() // 1 applied count
        {
            var result = context.StudentDrives.Where(x => x.StatusId == 1).Count();
            return result;
        }

        public long GetTotalStudentCount()
        {
            var result = context.Users.Where(x => x.IsActive == 1 && x.RoleId == 1).Count();
            return result;
        }

        public long GetTotalStudentShortlisted() //2 shortlisted count
        {
            var result = context.StudentDrives.Where(x => x.StatusId == 2).Count();
            return result;
        }

        //public long GetTotalRejectedStudents() //2 shortlisted count
        //{
        //    var result = context.StudentDrives.Where(x => x.StatusId == 6).Count();
        //    return result;
        //}
        public long GetAppearedStudentCount()
        {
            var result = context.StudentDrives.Where(x => x.StatusId == 4).Count();
            return result;
        }
        public long GetNewShortlistedStudentCount()
        {
            var result = context.StudentDrives.Where(x =>x.StatusId == 3).Count();
            return result;
        }

        public IEnumerable<StatusDTO> GetStudentDriveStatusCount()
        {
            //StudentDriveStatus
            var Query = context.StudentDriveStatus.ToList();
            List<StatusDTO> list = new List<StatusDTO>();
            foreach(var item in Query)
            {
                StatusDTO status = new StatusDTO();
                var result = context.StudentDrives.Where(x => x.StatusId == item.StatusId).Count();
                
                status.Id = item.StatusId;
                status.Name = item.StatusName;
                status.Count = result;   
                list.Add(status);
            }
            return list;
        }

        public Dictionary<string, int> GetRejectedCandidateCountByTechnology()
        {
            var query = from b in context.Batchs
                        join t in context.technologies on b.TechnologyId equals t.TechnologyId
                        join s in context.Students on b.BatchId equals s.BatchId
                        join sd in context.StudentDrives on s.StudentId equals sd.StudentId
                        where sd.StatusId == 3
                        group sd.StatusId by new { sd.StatusId, b.TechnologyId, t.TechnologyName } into grouped
                        select new
                        {
                            TechnologyName = grouped.Key.TechnologyName,
                            SelectedCandidateCount = grouped.Count()
                        };

            return query.ToDictionary(x => x.TechnologyName, x => x.SelectedCandidateCount);
        }
    }
}
