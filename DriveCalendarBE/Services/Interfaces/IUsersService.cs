using DriveCalendarBE.Entities;
using DriveCalendarBE.Entities.DTO;

namespace DriveCalendarBE.Services.Interfaces
{
    public interface IUsersService
    {
        int Register(Users users);
        LoginOutput Login(Users users);
        List<UserOutPutDTO> GetUserOfPE();
        int UpdateUsers(Users users);
        int DeleteUser(int id);

        //Nilesh Jagtap Created on 03-11-2023 displays list of students and users
        IEnumerable<UserDto> GetAllStudentList();
        IEnumerable<Users> GetUsers();

    }
}
