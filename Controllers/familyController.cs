using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace todoapi_v00.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class familyController : ControllerBase
    {
        private readonly familyContext _context;

        public familyController(familyContext context)
        {
            _context = context;

        }

        // GET: api/todo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Family>>> GetFamily([FromQuery] string? nome, int page = 1, int pageSize = 10)
        {
            var queryable = _context.Familys.AsQueryable();

            if (!string.IsNullOrEmpty(nome))
            {
                await queryable.Where(x => x.Nome == nome).ToListAsync();
            }
            else
            {
                await _context.Familys.ToListAsync();
            }
            // Conta il numero totale di articoli prima della paginazione
            int totalArticles = await queryable.CountAsync();

            // Applica la paginazione solo se ci sono elementi da paginare
            if (totalArticles > 0)
            {
                // Applica la paginazione
                var paginatedArticles = await queryable.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

                // Calcola il numero totale di pagine
                int totalPages = (int)Math.Ceiling((double)totalArticles / pageSize);

                // Crea l'oggetto di risposta con i dati paginati
                var response = new
                {
                    Items = paginatedArticles,
                    TotalCount = totalArticles,
                    Page = page,
                    PageSize = pageSize,
                    TotalPages = totalPages
                };

                // Restituisci la risposta
                return Ok(response);
            }
            else
            {
                return Ok(new
                {
                    Items = new List<Article>(),
                    TotalCount = 0,
                    Page = page,
                    PageSize = pageSize,
                    TotalPages = 0
                });
            }
        }

        // GET: api/todo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Family>> GetTodoItem(long id)
        {
            var todoItem = await _context.Familys.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return todoItem;
        }

        // POST: api/Todo
        [HttpPost]
        public async Task<ActionResult<Family>> PostTodoItem(Family item)
        {
            _context.Familys.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTodoItem), new { id = item.Id_famiglia }, item);
        }

        // PUT: api/Todo/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItem(long id, Family item)
        {
            if (id != item.Id_famiglia)
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
            var todoItem = await _context.Familys.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            _context.Familys.Remove(todoItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}