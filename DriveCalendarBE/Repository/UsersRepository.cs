using DriveCalendarBE.Entities;
using DriveCalendarBE.Entities.DTO;
using DriveCalendarBE.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks.Dataflow;

namespace DriveCalendarBE.Repository
{
    public class UsersRepository : IUsersRepository
    {
        private readonly ApplicationDbContext _context;

        public int Ratings { get; private set; }

        public UsersRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Users Login(Users users)
        {
            var user = _context.Users.Where(x => x.UserName == users.UserName).FirstOrDefault();
            return user;
        }

        public int Register(Users users)
        {
            int result = 0;
            _context.Users.Add(users);
            result = _context.SaveChanges();
            return result;

        }
        public List<UserOutPutDTO> GetUserOfPE()
        {
            var users = (from u in _context.Users
                         where u.RoleId == 2
                         select new UserOutPutDTO
                         {
                             UserId = u.UserId,
                             UserName = u.UserName
                         }).ToList();
            return users;
        }
        /* 
          created by mudassar date 11/3/23
      description  for creating the function of  update for user repository class
         */
        public int UpdateUsers(Users users)
        {
            int result = 0;
            var usersInfo = _context.Users.Where(x => x.UserId == users.UserId).FirstOrDefault();
            if (usersInfo != null)
            {
                usersInfo.UserName = users.UserName;
                usersInfo.EmailId = users.EmailId;
                usersInfo.Password = users.Password;
                usersInfo.RoleId = users.RoleId;
                usersInfo.IsActive = 1;
                result = _context.SaveChanges();
            }
            return result;
        }
        /* 
          created by mudassar date 11/4/23
      description:   for creating the function of  delete for user repository class
         */
        public int DeleteUser(int id)
        {
            int result = 0;
            var userinf = _context.Users.Where(x => x.UserId == id).FirstOrDefault();
            if (userinf != null)
            {
                userinf.IsActive = 0;
                result = _context.SaveChanges();
            }
            return result;
        }

        //Nilesh Jagtap Created on 03-11-2023 displays list of students and users
       
        public IEnumerable<UserDto> GetAllStudentList()
        {
           
            var userDtos = new List<UserDto>();

            var users = _context.Users.Where(x => x.IsActive == 1 && x.RoleId == 1).ToList();

            foreach (var user in users)
            {
                UserDto dto = new UserDto
                {
                   UserId = user.UserId,
                   //StuId = user.UserId,
                  UserName = user.UserName,
                    EmailId = user.EmailId,
                  //  Password = user.Password,
                    RoleId = user.RoleId,
                    IsActive = 1
                };

                var student = (
                    from s in _context.Students
                    join batch in _context.Batchs on s.BatchId equals batch.BatchId
                    join studentmode in _context.StudentModes on s.StudentModeId equals studentmode.StudentModeId
                    where s.UserId == user.UserId
                    select new UserDto
                    {
                        UserId = s.UserId,
                        StudentId = s.StudentId,
                        Ratings = s.Ratings,
                        StudentName = s.StudentName,
                        BatchId =batch.BatchId,
                        BatchName = batch.BatchName,
                        StudentModeId = s.StudentModeId,
                        StudentModeName = studentmode.StudentModeName,
                        CreatedBy=s.CreatedBy,
                        MobileNo=s.MobileNo,
                        AlternateMobileNo=s.AlternateMobileNo,
                        IsActive = 1

                    }).FirstOrDefault();

                if (student != null)
                {
                    dto.UserId=student.UserId;
                    dto.StudentId = student.StudentId;
                    dto.BatchId = student.BatchId;
                    dto.StudentName=student.StudentName;
                    dto.StudentModeId = student.StudentModeId;
                    dto.Ratings = student.Ratings;
                    dto.BatchName = student.BatchName;
                    dto.CreatedBy=student.CreatedBy;
                    dto.StudentModeName=student.StudentModeName;
                    dto.MobileNo=student.MobileNo;
                    dto.AlternateMobileNo =student.AlternateMobileNo;


                }
                userDtos.Add(dto);
            }

            return userDtos;

        }



        /*
        * created by - snehal shirsath
        * created date - 07/11/2023
        * desc - get users is not equal to 1
        */
        public IEnumerable<Users> GetUsers()
        {
            return _context.Users.Where(x => x.IsActive == 1 && x.RoleId != 1).ToList();            
        }
    }
}


            




          


        
    


    


       
    
    












