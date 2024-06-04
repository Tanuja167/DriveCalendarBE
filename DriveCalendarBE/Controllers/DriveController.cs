using DriveCalendarBE.Entities;
using DriveCalendarBE.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace DriveCalendarBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriveController : ControllerBase
    {
        private readonly IDriveService driveService;
        public DriveController(IDriveService driveService)
        {
            this.driveService = driveService;
        }
        // GET: api/<DriveController>
        [HttpGet]
        [Route("GetAllDrives")]
        public IActionResult GetAllDrives()
        {
            try
            {
              return new ObjectResult(driveService.GetAllDrives());
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex);
            }
        }

        // GET api/<DriveController>/5
        [HttpGet]
        [Route("GetDriveById/{id}")]
        public IActionResult GetDriveById(int id)
        {
            try
            {
                return new ObjectResult(driveService.GetDriveById(id));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex);
            }
        }

        // POST api/<DriveController>
        [HttpPost]
        [Route("AddDrive")]
        public IActionResult AddDrive([FromBody] Drive drive)
        {
            try
            {
                int result =driveService.AddDrive(drive);

                if (result==1)
                    return StatusCode(StatusCodes.Status201Created);
                else
                    return StatusCode(StatusCodes.Status500InternalServerError);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        // PUT api/<DriveController>/5
        [HttpPut]
        [Route("UpdateDrive")]
        public IActionResult UpdateDrive([FromBody] Drive drive)
        {
            try
            
            {
                int result = driveService.UpdateDrive(drive);
                if (result == 1)
                    return StatusCode(StatusCodes.Status200OK);
                else
                    return StatusCode(StatusCodes.Status500InternalServerError);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        // DELETE api/<DriveController>/5
        [HttpDelete]
        [Route("DeleteDrive/{id}")]
        public IActionResult DeleteDrive(int id)
        {
            try
            {
                int result = driveService.DeleteDrive(id);
                if (result == 1)
                    return StatusCode(StatusCodes.Status200OK);
                else
                    return StatusCode(StatusCodes.Status500InternalServerError);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }  
        //Vidyashree Hipparagi 02/11/2023
        // POST api/<DriveController> search controllser
        [HttpPost]
        [Route("SearchDrives")]
        public IActionResult SearchDrives([FromBody] SearchDTO searchQuery)
        {
            try
            {
                var result = driveService.SearchDrivesByString(searchQuery.searchString);

                if (result != null)
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
