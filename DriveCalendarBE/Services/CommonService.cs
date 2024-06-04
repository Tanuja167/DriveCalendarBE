using DriveCalendarBE.Entities;
using DriveCalendarBE.Repository.Interfaces;
using DriveCalendarBE.Services.Interfaces;

namespace DriveCalendarBE.Services
{
    public class CommonService : ICommonService
    {
        private readonly ICommonRepository repo;
        public CommonService(ICommonRepository repo)
        {
            this.repo = repo;
        }

        public IEnumerable<Round> GetAllRound()
        {
           return repo.GetAllRound();
        }

        /*  created by - girish jondhale
        created date - 05/11/2023
       desc - get list of student modes
       */
        public IEnumerable<StudentModes> GetAllStudentModes()
        {
            return repo.GetAllStudentModes();
        }

        public IEnumerable<Technology> GetAllTechnology()
        {
            return repo.GetAllTechnology();
        }

        /*
         * created by - snehal shirsath
         * created date - 06/11/2023
         * desc - get list of role
         */
        public IEnumerable<Roles> GetRoles()
        {
            return repo.GetRoles();
        }
    }
}
