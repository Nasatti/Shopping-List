using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace todoapi_v00.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class articleController : ControllerBase
    {
        private readonly articleContext _context;

        public articleController(articleContext context)
        {
            _context = context;

        }

        // GET: api/todo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Article>>> GetArticle([FromQuery] int? id_spesa, string? articolo, bool? acquistato, int page = 1, int pageSize = 10)
        {
            var queryable = _context.Articles.AsQueryable();

            if (!string.IsNullOrEmpty(id_spesa.ToString()) && !string.IsNullOrEmpty(acquistato.ToString()))
            {
                queryable = queryable.Where(x => x.Id_spesa == id_spesa);
                await queryable.Where(x => x.Acquistato == acquistato).ToListAsync();
            }
            else if (!string.IsNullOrEmpty(id_spesa.ToString()) && !string.IsNullOrEmpty(articolo))
            {
                queryable = queryable.Where(x => x.Id_spesa == id_spesa);
                await queryable.Where(x => x.Articolo == articolo).ToListAsync();
            }
            else if (!string.IsNullOrEmpty(id_spesa.ToString()))
            {
                await queryable.Where(x => x.Id_spesa == id_spesa).ToListAsync();
            }
            else if (!string.IsNullOrEmpty(articolo))
            {
                await queryable.Where(x => x.Articolo == articolo).ToListAsync();
            }
            else
            {
                await _context.Articles.ToListAsync();
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
        public async Task<ActionResult<Article>> GetTodoItem(long id)
        {
            var todoItem = await _context.Articles.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return todoItem;
        }

        // POST: api/Todo
        [HttpPost]
        public async Task<ActionResult<Article>> PostTodoItem(Article item)
        {
            _context.Articles.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTodoItem), new { id = item.Id_articolo }, item);
        }

        // PUT: api/Todo/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItem(long id, Article item)
        {
            if (id != item.Id_articolo)
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
            var todoItem = await _context.Articles.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            _context.Articles.Remove(todoItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}