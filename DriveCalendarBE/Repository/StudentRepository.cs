using DriveCalendarBE.Entities;
using DriveCalendarBE.Entities.DTO;
using DriveCalendarBE.Repository.Interfaces;
using Microsoft.VisualBasic;
using System.Buffers.Text;
using System.Text.RegularExpressions;
using System;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Microsoft.EntityFrameworkCore;

namespace DriveCalendarBE.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _context;
        public StudentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public int AddStudent(Student student)
        {
            int result = 0;
            //student.CreatedDate = DateTime.Now;
            _context.Students.Add(student);
            result = _context.SaveChanges();
            return result;
        }

        //public int DeleteStudent(int StudentId)
        //{
        //    int result = 0;
        //    var stud = _context.Students.Where(x => x.Id == StudentId).FirstOrDefault();
        //    if (stud != null)
        //    {
        //        stud.IsActive = 0;
        //        result = _context.SaveChanges();
        //    }
        //    return result;
        //}
       

        public IEnumerable<StudentDtetailsDto> GetAllStudents()
        {
            IEnumerable<StudentDtetailsDto> studentDetails = new List<StudentDtetailsDto>();

            studentDetails = (from s in _context.Students
                              from student in _context.Students
                              join user in _context.Users on student.UserId equals user.UserId
                              join b in _context.Batchs on s.BatchId equals b.BatchId
                              select new StudentDtetailsDto
                              {
                                  Id = s.StudentId,
                                  StudentId = user.UserId,
                                  BatchId = b.BatchId,
                                  BatchName = b.BatchName,
                                  StudentName = s.StudentName,
                                  Ratings = s.Ratings,
                                  IsActive = s.IsActive
                              }).Where(x => x.IsActive == 1).ToList();
            return studentDetails;

            // return _context.Students.Where(x => x.IsActive == 1).ToList();
        }

        public Student GetStudentById(int StudentId)
        {
            var stud = _context.Students.Where(x => x.StudentId == StudentId).FirstOrDefault();
            return stud;
        }

        //public int UpdateStudent(Student student)
        //{
        //    int result = 0;
        //    var stud = _context.Students.Where(x => x.UserId == student.UserId).FirstOrDefault();
        //    if (stud != null)
        //    {
        //        stud.CreatedDate = DateTime.Now;
        //        stud.UserId = student.UserId;
        //        stud.BatchId = student.BatchId;
        //        stud.Ratings = student.Ratings;
        //        stud.IsActive = 1;
        //        result = _context.SaveChanges();
        //    }
        //    return result;
        //}

        public IEnumerable<StudentDtetailsDto> GetStudents()
        {
            IEnumerable<StudentDtetailsDto> students = new List<StudentDtetailsDto>();
            students = (
                from student in _context.Students
                join user in _context.Users on student.UserId equals user.UserId
                join batch in _context.Batchs on student.BatchId equals batch.BatchId
                where student.IsActive == 1



                select new StudentDtetailsDto
                {
                    Id = student.StudentId,
                    StudentId = student.UserId,
                    // StudentName = user.UserName,
                    EmailId = user.EmailId,
                    RoleId = user.RoleId,
                    BatchId = batch.BatchId,
                    //StudentId=user.UserId,
                    StudentName = user.UserName,
                    UserName = user.UserName,
                    BatchName = batch.BatchName,
                    Ratings = student.Ratings,
                    StudentModelId = student.StudentModeId,
                    IsActive = student.IsActive,

                }).ToList();
            return students;

        }


        /*Vidyashree Hipparagi
         * Created Date:
         * Desc: Created new API for GetStudentByUserId
         */
        //public UserDto GetStudentByUserId(int userId)
        //{
        //    Users user = _context.Users.FirstOrDefault(x => x.UserId == userId && x.IsActive == 1);
        //    if (user != null)
        //    {
        //        UserDto dto = new UserDto();
        //        dto.UserId = user.UserId;
        //        dto.StudentName = user.UserName;
        //        dto.EmailId = user.EmailId;
        //        dto.RoleId = user.RoleId;

        //        Student student = _context.Students.FirstOrDefault(s => s.StudentId == userId);

        //        if (student != null)
        //        {
        //            dto.Id = student.Id;
        //            dto.Ratings = student.Ratings;
        //            dto.BatchId = student.BatchId;
        //            dto.StudentModelId = student.StudentModelId;
        //            dto.CreatedBy = student.CreatedBy;
        //            dto.CreatedDate = student.CreatedDate = DateTime.Now;

        //        }
        //        return dto;
        //    }
        //    return null;


        //}
        public Student GetStudentByUserId(int studentid)
        {
            var model = _context.Students.Where(x => x.StudentId == studentid).FirstOrDefault();
            return model;
            //var query = from user in _context.Users

            //            join student in _context.Students on user.UserId equals student.UserId into studentGroup

            //            where user.UserId == userId && user.IsActive == 1
            //            select new
            //            {
            //                User = user,
            //                Student = studentGroup.FirstOrDefault()
            //            };

            //var result = query.FirstOrDefault();

            //var temp = (from sm in _context.StudentModes
            //            where sm.StudentModeId == result.Student.StudentModeId
            //            select new
            //            {
            //                StudentModeName = sm.StudentModeName,
            //            }).FirstOrDefault();

            //if (result != null && result.User != null)
            //{
            //    UserDto dto = new UserDto
            //    {
            //        UserId = result.User.UserId,
            //        UserName = result.User.UserName,
            //        EmailId = result.User.EmailId,
            //        RoleId = result.User.RoleId

            //    };

            //    if (result.Student != null)
            //    {
            //        // dto.StudentId = result.Student.StudentId;
            //        dto.UserId = result.Student.UserId;
            //        dto.Ratings = result.Student.Ratings;
            //        dto.BatchId = result.Student.BatchId;
            //        dto.StudentModeId = result.Student.StudentModeId;
            //        dto.StudentModeName = temp.StudentModeName;
            //        dto.CreatedBy = result.Student.CreatedBy;
            //        dto.StudentName = result.Student.StudentName;
            //        dto.CreatedDate = DateTime.Now;
            //        dto.MobileNo = result.Student.MobileNo;
            //        dto.AlternateMobileNo = result.Student.AlternateMobileNo;
            //        dto.IsActive = 1;

            //    }
            //    return dto;
            //}

            //                studentResult = _context.SaveChanges();
            //            }
            //        else
            //        {
            //            Student studs = new Student
            //            {
            //                StudentId = userDto.UserId,
            //                BatchId = userDto.BatchId,
            //                Ratings = userDto.Ratings,
            //                 CreatedDate = DateTime.Now,
            //             CreatedBy = userDto.CreatedBy,
            //            StudentModelId = userDto.StudentModelId,
            //                IsActive = 1
            //            };
            //            _context.Students.Add(studs);
            //            studentResult = _context.SaveChanges();
            //        }
            //    }
            //    }
                
        
            //return userResult + studentResult;
        }
        public int DeleteStudent(int id)
        {
            int result = 0;

                var user = _context.Users.SingleOrDefault(x => x.UserId == id && x.IsActive == 1);

                if (user != null)
                {

                     user.IsActive = 0;

                    var student = _context.Students.Where(s => s.StudentId == user.UserId && s.IsActive == 1);

                    foreach (var detail in student)
                    {
                        detail.IsActive = 0;
                    }

                    result = _context.SaveChanges();
                }
            
            return result;
        }

        public int UpdateStudent(Student student)
        {
            throw new NotImplementedException();
        }

        public int UpdateUsers(Student student)
        {
            throw new NotImplementedException();
        }

        //public int DeleteStudent(int studentId)
        //{
        //    int result = 0;
        //    try
        //    {
        //        // var student = _context.Students.SingleOrDefault(x => x.Id == studentId && x.IsActive == 1);
        //        var student = _context.Students.Where(x => x.StudentId == studentId && x.IsActive==1).FirstOrDefault();
        //        if (student != null)
        //        {
        //            student.IsActive = 0;
        //            result = _context.SaveChanges();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"An error occurred: {ex.Message}");

        //    }

        //    return result;
        //}
    }
}              
                
            
           
        





