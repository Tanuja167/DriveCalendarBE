using DriveCalendarBE.Entities;
using DriveCalendarBE.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DriveCalendarBE.Repository
{
    public class CommonRepository : ICommonRepository
    {
        
        private readonly ApplicationDbContext _context;
        public CommonRepository(ApplicationDbContext context) 
        {
            _context = context;
        }

        /* created by - Akshata Sabne
        created date - 23/11/2023
        description - to get  list of DriveRounds
        */

        public IEnumerable<Round> GetAllRound()
        {
            return _context.Rounds.ToList(); 
        }

        /*  created by - girish jondhale
         created date - 05/11/2023
        desc - get list of student modes
        */
        public IEnumerable<StudentModes> GetAllStudentModes()
        {
           return _context.StudentModes.ToList();
        }

        public IEnumerable<Technology> GetAllTechnology()
        {
            return _context.technologies.ToList();
        }

        /*
* created by - snehal shirsath
* created date - 06/11/2023
* desc - get list of role
*/
        public IEnumerable<Roles> GetRoles()
        {
            return _context.Roles.ToList();
        }
    }
}

