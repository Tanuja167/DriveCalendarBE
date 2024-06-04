using DriveCalendarBE.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DriveCalendarBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentDriveStatusController : ControllerBase
    {
        private readonly IStudentDriveStatusService service;
        public StudentDriveStatusController(IStudentDriveStatusService service)
        {
            this.service = service;
        }
        [HttpGet]
        [Route("GetAllStudentDriveStatus")]
        public IActionResult GetAllStudentDriveStatus()
        {
            return new ObjectResult(service.GetAllStudentDriveStatus());
        }
    }
}
