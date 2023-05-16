using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace todoapi_v00.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class userController : ControllerBase
    {
        private readonly userContext _context;

        public userController(userContext context)
        {
            _context = context;

        }

        // GET: api/todo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUser([FromQuery] string? cognome, string?nome, string?email, int?id_famiglia)
        {
            var queryable = _context.Users.AsQueryable();

            if(!string.IsNullOrEmpty(cognome) && !string.IsNullOrEmpty(nome))
            {
                queryable = queryable.Where(x => x.Cognome == cognome);
                return await queryable.Where(x => x.Nome == nome).ToListAsync();
            }
            else if (!string.IsNullOrEmpty(cognome))
            {
                return await queryable.Where(x => x.Cognome == cognome).ToListAsync();
            }
            else if (!string.IsNullOrEmpty(nome))
            {
                return await queryable.Where(x => x.Nome == nome).ToListAsync();
            }
            else if (!string.IsNullOrEmpty(email))
            {
                return await queryable.Where(x => x.Email == email).ToListAsync();
            }
            else if (!string.IsNullOrEmpty(id_famiglia.ToString()))
            {
                return await queryable.Where(x => x.Id_famiglia == id_famiglia).ToListAsync();
            }
            else
            {
                return await _context.Users.ToListAsync();
            }
        }

        // GET: api/todo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetTodoItem(long id)
        {
            var todoItem = await _context.Users.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return todoItem;
        }

        // POST: api/Todo
        [HttpPost]
        public async Task<ActionResult<User>> PostTodoItem(User item)
        {
            _context.Users.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTodoItem), new { id = item.Id_utente }, item);
        }

        // PUT: api/Todo/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItem(long id, User item)
        {
            if (id != item.Id_utente)
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Todo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(long id)
        {
            var todoItem = await _context.Users.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            _context.Users.Remove(todoItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}