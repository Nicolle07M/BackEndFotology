using BackEndFotology.Data;
using BackEndFotology.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ProyectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComentariosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ComentariosController(ApplicationDbContext context)
        {

            this._context = context;
        }

        // GET: api/<ComentariosController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Comentario>>> Get()
        {
            if (_context.Comentarios == null)
            {
                return NotFound();
            }

            return await _context.Comentarios.ToListAsync();

        }

        // GET api/<ComentariosController>/5
        [HttpGet("{id}")] // Variables de ruta  https://localhost:7030/api/comentarios/5 
        public async Task<ActionResult<Comentario>> Get(int id)
        {

            if (_context.Comentarios == null
)
            {
                return NotFound();
            }

            var comentario = await _context.Comentarios.FindAsync(id);

            if (comentario is null)
            {
                return NotFound();
            }

            return comentario;
        }

        // POST api/<ClienteController>
        [HttpPost]
        public async Task<ActionResult<Comentario>> Post([FromBody] Comentario comentario)
        {
            if (_context.Comentarios == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Comentario'  is null.");
            }
            _context.Comentarios.Add(comentario);
            await _context.SaveChangesAsync();
            return CreatedAtAction("Get", new { id = comentario.IDcomentario }, comentario);
        }

        // PUT api/<ComentariosController>/5
        // PUT api/Comentarios/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Comentario comentario)
        {

            if (id != comentario.IDcomentario)
            {
                return BadRequest();
            }
            _context.Entry(comentario).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

                if (!ComentariosExists(id))
                {
                    return NotFound();
                }
                else
                {
                    return BadRequest();
                }
            }
            return NoContent();
        }

        private bool ComentariosExists(int id)
        {
            return (_context.Comentarios?.Any(c => c.IDcomentario == id)).GetValueOrDefault();
        }


        // DELETE api/<ComentariosController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (_context.Comentarios is null)
            {
                return NotFound();
            }

            var comentario = await _context.Comentarios.FirstOrDefaultAsync(c => c.IDcomentario == id);
            if (comentario == null)
            {
                return NotFound();
            }

            _context.Comentarios.Remove(comentario);
            await _context.SaveChangesAsync();
            return NoContent();

        }
    }

}
