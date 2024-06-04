using DriveCalendarBE.Services;
using DriveCalendarBE.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using DriveCalendarBE.Entities;
using Microsoft.AspNetCore.Http;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DriveCalendarBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpdateStudentProfileController : ControllerBase
    {
        // GET: api/<UpdateStudentProfileController>
        private readonly IUpdateStudentProfileService updateStudentProfileService;

        public UpdateStudentProfileController(IUpdateStudentProfileService updateStudentProfileService)
        {
            this.updateStudentProfileService = updateStudentProfileService;
        }

     
       

        // GET api/<UpdateStudentProfileController>/5
        [HttpGet]
        [Route("GetStudentById/{studentId}")]

        public IActionResult GetStudentById(int studentId)
        {
            try
            {
                return new ObjectResult(updateStudentProfileService.GetStudentById(studentId));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status204NoContent, ex);
            }
        }

        // POST api/<UpdateStudentProfileController>
        

        // PUT api/<UpdateStudentProfileController>/5
        [HttpPut]
        [Route("UpdateStudentProfile")]

     
        public IActionResult UpdateStudentProfile([FromBody] Student student)
        {
            try
            {
                int result = updateStudentProfileService.UpdateStudentProfile(student);
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

     
    }
}
