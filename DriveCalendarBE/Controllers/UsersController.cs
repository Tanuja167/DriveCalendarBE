using DriveCalendarBE.Entities;
using DriveCalendarBE.Repository;
using DriveCalendarBE.Services;
using DriveCalendarBE.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DriveCalendarBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService usersService;
        private readonly IConfiguration configuration;
        public UsersController(IUsersService usersService, IConfiguration configuration)
        {
            this.usersService = usersService;
            this.configuration = configuration;
        }

        [HttpPost]
        [Route("Register")]
        public IActionResult Register([FromBody] Users users)
        {
            try
            {
                int result = usersService.Register(users);
                if (result == 1)
                {
                    return StatusCode(StatusCodes.Status200OK);
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex);
            }
        }
        [HttpPost]
        [Route("Login")]
        public IActionResult Login([FromBody] Users user)
        {
            try
            {
                LoginOutput u = usersService.Login(user);
                if (u != null)
                {
                    return Ok(u);
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex);
            }
        }
        [HttpGet]
        [Route("GetUserByRolePE")]
        public IActionResult GetUserByRolePE()
        {
            try
            {
                return new ObjectResult(usersService.GetUserOfPE());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex);
            }

        }

       /*
        created by mudassar date 11/3/23
        discriotion:for creating the function of  update for user 
        */
        [HttpPut]
        [Route("UpdateUsers")]
        public IActionResult UpdateUseres([FromBody] Users users)
        {
            try
            {
                int result = usersService.UpdateUsers(users);
                if (result == 1)
                    return StatusCode(StatusCodes.Status200OK);
                else
                    return StatusCode(StatusCodes.Status500InternalServerError);
             }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex);
            }
        }
        /*
        * created by - snehal shirsath
        * created date - 06/11/2023
        * desc - get users
        */

        [HttpGet]
        [Route("GetUsers")]
        public IActionResult GetUsers()
        {
            try
            {
                return new ObjectResult(usersService.GetUsers());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex);
            }
        }

        /*
        created by mudassar date 11/4/23
        discriotion: for creating the function of  delete for user
     */
        [HttpDelete]
        [Route("DeleteUser")]
        public IActionResult DeleteUser([FromBody] int id)
        {
            try
            {
                int result = usersService.DeleteUser(id);
                if (result == 1)
                {
                    return StatusCode(StatusCodes.Status200OK);
                }
                else
                {
                  return StatusCode(StatusCodes.Status500InternalServerError);
                }
           
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status400BadRequest, ex);
            }
        }

        //[HttpGet]
        //[Route("GetUserList")]
        //public ActionResult GetUserList()
        //{
        //    try
        //    {
        //        return new ObjectResult(usersService.GetUserList());
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(StatusCodes.Status204NoContent, ex.Message);
        //    }

        //}

        //Nilesh Jagtap Created on 03-11-2023 displays list of students and users
        [HttpGet]
        [Route("GetAllStudentList")]
        public IActionResult GetAllStudentList()
        {
            try
            {
                return new ObjectResult(usersService.GetAllStudentList());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status204NoContent, ex.Message);
            }

        }
    }
}
