using DriveCalendarBE.Entities;
using DriveCalendarBE.Entities.DTO;
using DriveCalendarBE.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DriveCalendarBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardService servie;
        public DashboardController(IDashboardService servie)
        {
            this.servie = servie;
        }


        [HttpPost]
        [Route("GetFilterDate")]
        public IActionResult GetFilterDate([FromBody] CommonDTO getDate)
        {
            return null;
        }




        [HttpGet]
        [Route("GetTotalDriveCount")]
        public IActionResult GetTotalDriveCount()
        {
            try
            {
                return new ObjectResult(servie.GetTotalDriveCount());

            }
            catch(Exception ex)
            {
               return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
            
        }
        [HttpGet]
        [Route("GetTotalPlacementCount")]
        public IActionResult GetTotalPlacementCount()
        {
            try
            {
                return new ObjectResult(servie.GetSelectedCandidateCountByTechnology());

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
        [HttpGet]
        [Route("GetTotalStudentApplied")]
        public IActionResult GetTotalStudentApplied()
        {
            try
            {
                return new ObjectResult(servie.GetTotalStudentApplied());

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
        [HttpGet]
        [Route("GetTotalStudentCount")]
        public IActionResult GetTotalStudentCount()
        {
            try
            {
                return new ObjectResult(servie.GetTotalStudentCount());

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
        [HttpGet]
        [Route("GetTotalStudentShortlisted")]
        public IActionResult GetTotalStudentShortlisted()
        {
            try
            {
                return new ObjectResult(servie.GetTotalStudentShortlisted());

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
        [HttpGet]
        [Route("GetTotalRejectedStudents")]
        public IActionResult GetTotalRejectedStudents()
        {
            try
            {
                return new ObjectResult(servie.GetRejectedCandidateCountByTechnology());

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
        [HttpGet]
        [Route("GetAppearedStudentCount")]
        public IActionResult GetAppearedStudentCount()
        {
            try
            {
                return new ObjectResult(servie.GetAppearedStudentCount());

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
        [HttpGet]
        [Route("GetNewShortlistedStudentCount")]
        public IActionResult GetNewShortlistedStudentCount()
        {
            try
            {
                return new ObjectResult(servie.GetNewShortlistedStudentCount());

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
        [HttpGet]
        [Route("GetStudentDriveStatusCount")]
        public IActionResult GetStudentDriveStatusCount()
        {
            try
            {
                return new ObjectResult(servie.GetStudentDriveStatusCount());

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}
