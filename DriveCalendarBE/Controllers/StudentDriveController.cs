using DriveCalendarBE.Entities;
using DriveCalendarBE.Entities.DTO;
using DriveCalendarBE.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DriveCalendarBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentDriveController : ControllerBase
    {
        private readonly IStudentDriveService service;
        public StudentDriveController(IStudentDriveService service)
        {
            this.service = service;
        }
        //[HttpPost]
        //[Route("ApplyToDrive")]
        //public IActionResult ApplyToDrive(StudentDrive drive) 
        //{
        //    try
        //    {
        //        int result=service.ApplyToDrive(drive);
        //        if (result == 1)
        //            return StatusCode(StatusCodes.Status201Created);
        //        else
        //            return StatusCode(StatusCodes.Status500InternalServerError);
        //    }
        //    catch(Exception ex)
        //    {
        //        return StatusCode(StatusCodes.Status422UnprocessableEntity, ex);
        //    }
        //}
        [HttpPut]
        [Route("UpdateStudentDrive")]
        public IActionResult UpdateStudentDrive(StudentDrive drive)
        {
            try
            {
                int result = service.UpdateStudentDrive(drive);
                if (result == 1)
                    return StatusCode(StatusCodes.Status200OK);
                else
                    return StatusCode(StatusCodes.Status500InternalServerError);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status422UnprocessableEntity, ex);
            }
        }
        [HttpDelete]
        [Route("DeleteStudentDrive/{id}")]
        public IActionResult DeleteStudentDrive(int id)
        {
            try
            {
                int result = service.DeleteStudentDrive(id);
                if (result >= 1)
                    return StatusCode(StatusCodes.Status200OK);
                else
                    return StatusCode(StatusCodes.Status500InternalServerError);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status422UnprocessableEntity, ex);
            }
        }
        [HttpGet]
        [Route("GetStudentDrives")]
        public IActionResult GetStudentDrives()
        {
            try
            {
                return new ObjectResult( service.GetAllStudentDrives());
                
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status204NoContent, ex);
            }
        }

        

        [HttpPost] 
        [Route("AddStudentToDrive")]
        public IActionResult AddStudentToDrive(StudentDriveDto studentDriveDetails)
        {
            try
            {
                int result = service.AddStudentToDrive(studentDriveDetails);
                if (result == 1)
                    return StatusCode(StatusCodes.Status201Created);
                else
                    return StatusCode(StatusCodes.Status500InternalServerError);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status422UnprocessableEntity, ex);
            }
        }

        [HttpPut]
        [Route("UpdateStudentToDrive")]
        public IActionResult UpdateStudentToDrive(StudentDriveDto studentDriveDetails)
        {
            try
            {
                int result = service.UpdateStudentToDrive(studentDriveDetails);
                if (result >= 1)
                    return StatusCode(StatusCodes.Status201Created);
                else
                    return StatusCode(StatusCodes.Status500InternalServerError);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status422UnprocessableEntity, ex);
            }
        }

        [HttpPost]
        [Route("GetStudentDrivesByDateRange")]
        public IActionResult GetStudentDrivesByDateRange([FromBody] StudentDriveOutputDto dates)
        {
            try
            {
                var result = service.GetStudentDrivesByDateRange(dates.StartDate, dates.EndDate);

                if (result != null && result.Any())
                    return new ObjectResult(result);
                else
                    return StatusCode(StatusCodes.Status204NoContent);         
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

    }
}
