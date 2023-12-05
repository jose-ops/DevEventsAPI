using AwesomeDevEventsAPI.Entities;
using AwesomeDevEventsAPI.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AwesomeDevEventsAPI.Controllers
{
    [Route("api/dev-events")]
    [ApiController]
    public class DevEventsController : ControllerBase
    {
        private readonly DevEventsDbContext _context;
        public DevEventsController(DevEventsDbContext context)
        {
            _context = context;
            
        }

        // api/dev-events GET
        [HttpGet]
        public IActionResult GetAll()
        {
            var devEvents = _context.DevEvents.Where(d => !d.IsDeleted).ToList();
            return Ok(devEvents);
        }

        // api/dev-events/123123 GET
        [HttpGet]
        public IActionResult GetById( Guid id)
        {
            var devEvent = _context.DevEvents.SingleOrDefault(d => d.Id == id);
            if(devEvent == null)
            {
                return NotFound();
            }
            return Ok(devEvent);
        }

        // api/dev-events/ POST
        [HttpPost]
        public IActionResult Post(DevEvents devEvents)
        {
            _context.DevEvents.Add(devEvents);

            return CreatedAtAction(nameof(GetById), new { id = devEvents.Id}, devEvents);
        } 

        //api/dev-events/12345123 PUT
        [HttpPut("{id}")]
        public IActionResult Update(Guid id, DevEvents input)
        {
            var devEvent = _context.DevEvents.SingleOrDefault(d => d.Id == id);
            if (devEvent == null)
            {
                return NotFound();
            }

            devEvent.Update(input.Title, input.Description, input.StartDate, input.EndDate);

            return NoContent();
        }

        // api/dev-events/123234 DELETE
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var devEvent = _context.DevEvents.SingleOrDefault(d => d.Id == id);
            if (devEvent == null)
            {
                return NotFound();
            }

            devEvent.Delete();

            return NoContent();

        }
    }
}
