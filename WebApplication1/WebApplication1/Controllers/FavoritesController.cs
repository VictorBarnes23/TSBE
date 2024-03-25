using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoritesController : ControllerBase
    {
        private TicketSystemContext dbContext = new TicketSystemContext();

        [HttpGet]
        public IActionResult Get(string id)
        {
            List<int> favList = dbContext.Favorites.Where(f => f.UserId == id).Select(f => f.TicketId).ToList();

            List<Ticket> list = dbContext.Tickets.Where(t => favList.Contains(t.Id)).ToList();

            if (list == null)
            {
                return NotFound();
            }
            else { return Ok(list); }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Favorite f)
        {
            f.Id = 0;
            dbContext.Favorites.Add(f);
            dbContext.SaveChanges();
            return CreatedAtAction(nameof(Get), new
            {
                id = f.Id
            }, f);
        }
    }

}
