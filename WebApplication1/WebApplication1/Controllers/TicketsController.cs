using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private TicketSystemContext dbContext = new TicketSystemContext();

        [HttpGet]
        public IActionResult GetAll(string? filter)
        {
            List<Ticket> result = dbContext.Tickets.ToList();
            if (filter != null)
            {
                return Ok(result.Where(t => t.Title.ToLower().Trim() == filter.ToLower().Trim()));
            }
            else
            {
                return Ok(result);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id) {
            Ticket result = dbContext.Tickets.FirstOrDefault(t => t.Id == id);
            if(result == null)
            {
                return NotFound();
            }
            else { return Ok(result); }
        }

        [HttpPost]
        public IActionResult Add([FromBody] Ticket t) {
            t.Id = 0;
            dbContext.Tickets.Add(t);
            dbContext.SaveChanges();
            return CreatedAtAction("Get", new
            {
                id = t.Id
            }, t);
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromBody] Ticket t, int id)
        {
            if (t.Id != id)
            {
                return BadRequest();
            }
            else if (!dbContext.Tickets.Any(t => t.Id == id)) 
            { 
                return NotFound(); 
            }
            else
            {
                dbContext.Tickets.Update(t);
                dbContext.SaveChanges();    
                return NoContent();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Ticket result = dbContext.Tickets.FirstOrDefault(t => t.Id == id);
            if(result == null) {
                return NotFound();
            }
            dbContext.Tickets.Remove(result);
            dbContext.SaveChanges();
            return NoContent();
        }


    }
}
