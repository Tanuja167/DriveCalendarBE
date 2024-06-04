using DriveCalendarBE.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using DriveCalendarBE.Entities;

namespace DriveCalendarBE.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class BatchController : ControllerBase
    {
        private readonly IBatchService batchService;

        public BatchController(IBatchService batchService)
        {
            this.batchService = batchService;
        }

        // POST api/<BatchController>
        [HttpPost]
        [Route("AddBatch")]
        public IActionResult AddBatch([FromBody] Batch batch)
        {
          
            try
            {
                int result = batchService.AddBatch(batch);
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


        // GET: api/<BatchController>
        [HttpGet]
        [Route("GetAllBatches")]
        public IActionResult GetAllBatch()
        {
            try
            {
                return new ObjectResult(batchService.GetAllBatches());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status204NoContent, ex);
            }
        }


        // GET api/<StudentController>/5
        [HttpGet]
        [Route("GetBatchById/{id}")]
        public IActionResult GetBatchById(int id)
        {
            try
            {
                return new ObjectResult(batchService.GetBatchById(id));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status204NoContent, ex);
            }
        }


        // DELETE api/<BatchController>/
        [HttpDelete]
        [Route("DeleteBatch/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                int result = batchService.DeleteBatch(id);
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

        // PUT api/<StudentController>/5
        [HttpPut]
        [Route("UpdateBatch")]
        public IActionResult UpdateBatch([FromBody] Batch batch)
        {
            try
            {
                int result = batchService.UpdateBatch(batch);
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
