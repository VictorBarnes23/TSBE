using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using WebApplication1.Models;
using WebApplication1.Models.DTOs;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private TicketSystemContext dbContext = new TicketSystemContext();

        private static TicketDTO ConvertDTO(Ticket t)
        {
            return new TicketDTO
            {
                Id = t.Id,
                Title = t.Title,
                Description = t.Description,
                Name = t.Name,
                Resolver = t.Resolver,
                Completed = t.Completed,
                Favorites = t.Favorites.Select(f => f.UserId.ToString()).ToList(),
            };
        }

        [HttpGet]
        public IActionResult GetAll(string? filter)
        {
            List<TicketDTO> result = dbContext.Tickets.Include(f => f.Favorites).Select((Ticket t) => ConvertDTO(t)).ToList();
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
        public IActionResult Update([FromBody] TicketDTO t, int id)
        {
            Ticket Tickets = dbContext.Tickets.Find(id);
            
            if (Tickets == null)
            {
                return BadRequest();
            }
            else if (!dbContext.Tickets.Any(t => t.Id == id)) 
            { 
                return NotFound(); 
            }
            else
            {
                if(t.Title != null)
                {
                    Tickets.Title = t.Title;
                }
                if (t.Description != null)
                {
                    Tickets.Description = t.Description;
                }
                if (t.Resolution != null)
                {
                    Tickets.Resolution = t.Resolution;
                }
                if (t.Name != null)
                {
                    Tickets.Name = t.Name;
                }
                if (t.Resolver != null)
                {
                    Tickets.Resolver = t.Resolver;
                }
                if (t.Completed != null)
                {
                    Tickets.Completed = t.Completed;
                }
                dbContext.Tickets.Update(Tickets);
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
