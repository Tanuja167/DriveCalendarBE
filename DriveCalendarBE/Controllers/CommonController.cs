using DriveCalendarBE.Services;
using DriveCalendarBE.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DriveCalendarBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommonController : ControllerBase
    {
        private readonly ICommonService service;
        public CommonController(ICommonService service)
        {
            this.service = service;
        }

        /*  created by - girish jondhale
        created date - 05/11/2023
       desc - get list of student modes
       */
        [HttpGet]
        [Route("GetAllStudentModes")]
        public IActionResult GetAllStudentModes()
        {
            try
            {

            return new ObjectResult(service.GetAllStudentModes());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status204NoContent, ex);
            }

        }

        /*
       * created by - snehal shirsath
       * created date - 06/11/2023
       * desc - get list of role
       */
        [HttpGet]
        [Route("GetRoles")]
        public IActionResult GetRoles()
        {
            try
            {
                return new ObjectResult(service.GetRoles());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex);
            }
        }
        /* created by - Akshata Sabne
       created date - 23/11/2023
       description - to get  list of DriveRounds
       */
        [HttpGet]
        [Route("GetRounds")]
        public IActionResult GetRounds()
        {
            try
            {
                return new ObjectResult(service.GetAllRound());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex);
            }
        }
        [HttpGet]
        [Route("GetTechnologies")]
        public IActionResult GetTechnologies()
        {
            try
            {
                return new ObjectResult(service.GetAllTechnology());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex);
            }
        }
    }
}
