using DriveCalendarBE.Entities;
using DriveCalendarBE.Entities.DTO;
using DriveCalendarBE.Services;
using DriveCalendarBE.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DriveCalendarBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService studentSerive;
        public StudentController(IStudentService studentSerive)
        {
            this.studentSerive = studentSerive;
        }

        // GET: api/<StudentController>
        [HttpGet]
        [Route("GetAllStudents")]
        public IActionResult GetAllStudents()
        {
            try
            {
                return new ObjectResult(studentSerive.GetAllStudents());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status204NoContent, ex);
            }
        }

        // GET: api/<StudentController>
        [HttpGet]
        [Route("GetStudents")]
        public IActionResult GetStudents()
        {
            try
            {
                return new ObjectResult(studentSerive.GetStudents());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status204NoContent, ex);
            }
        }


        // GET api/<StudentController>/5
        [HttpGet]
        [Route("GetStudentById/{id}")]
        public IActionResult Get(int StudentId)
        {
            try
            {
                return new ObjectResult(studentSerive.GetStudentById(StudentId));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status204NoContent, ex);
            }
        }

        // POST api/<StudentController>
        [HttpPost]
        [Route("AddStudent")]
        public IActionResult AddStudent([FromBody] Student student)
        {
            try
            {
                int result = studentSerive.AddStudent(student);
                if (result == 1)
                    return StatusCode(StatusCodes.Status201Created);
                else
                    return StatusCode(StatusCodes.Status500InternalServerError);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex);
            }

        }

       
        // DELETE api/<StudentController>/5
        [HttpDelete]
        [Route("DeleteStudent/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                int result = studentSerive.DeleteStudent(id);
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

       

        /*Vidyashree Hipparagi
       * Created Date:
       * Desc: Created new API for GetStudentByUserId
       */
        [HttpGet]
        [Route("GetStudentByUserId/{id}")]
        public IActionResult GetStudentByUserId(int id)
        {

            try
            {
                var student = studentSerive.GetStudentByUserId(id);
                if (student != null)
                {
                    return new ObjectResult(student);
                }
                else
                {
                    return StatusCode(StatusCodes.Status204NoContent);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status422UnprocessableEntity, ex);
            }
        }


                [HttpPut]
                [Route("UpdateUsers")]
                public IActionResult UpdateUsers([FromBody] Student student)
                {
                    try
                    {
                        int result = studentSerive.UpdateUsers(student);
                        if (result >= 0)
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
    
