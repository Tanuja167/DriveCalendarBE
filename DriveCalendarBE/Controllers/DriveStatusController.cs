using DriveCalendarBE.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DriveCalendarBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriveStatusController : ControllerBase
    {
        private readonly IDriveStatusService service;
        public DriveStatusController(IDriveStatusService service)
        {
            this.service = service;
        }
        [HttpGet]
        [Route("GetAllDriveStatus")]
        public IActionResult GetAllDriveStatus()
        {
            try
            {
                var result = service.GetAllStatus();
                return new ObjectResult(result);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status204NoContent, ex);
            }
        }
    }
}
