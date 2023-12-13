using BackEndFotology.Data;
using BackEndFotology.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ProyectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FotografiasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FotografiasController(ApplicationDbContext context)
        {

            this._context = context;
        }

        // GET: api/<FotografiasController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fotografia>>> Get()
        {
            if (_context.Fotografias == null)
            {
                return NotFound();
            }

            return await _context.Fotografias.ToListAsync();

        }

        // GET api/<FotografiasController>/5
        [HttpGet("{id}")] // Variables de ruta  https://localhost:7030/api/fotografias/5 
        public async Task<ActionResult<Fotografia>> Get(int id)
        {

            if (_context.Fotografias == null
)
            {
                return NotFound();
            }

            var fotografia = await _context.Fotografias.FindAsync(id);

            if (fotografia is null)
            {
                return NotFound();
            }

            return fotografia;
        }

        // POST api/<FotografiasController>
        [HttpPost]
        public async Task<ActionResult<Fotografia>> Post([FromBody] Fotografia fotografia)
        {
            if (_context.Fotografias == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Fotografias'  is null.");
            }
            _context.Fotografias.Add(fotografia);
            await _context.SaveChangesAsync();
            return CreatedAtAction("Get", new { id = fotografia.IDfotografia }, fotografia);
        }

        // PUT api/<FotografiasController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Fotografia fotografia)
        {

            if (id != fotografia.IDfotografia)
            {
                return BadRequest();
            }
            _context.Entry(fotografia).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

                if (!FotografiaExists(id))
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

        private bool FotografiaExists(int id)
        {
            return (_context.Fotografias?.Any(c => c.IDfotografia == id)).GetValueOrDefault();
        }


        // DELETE api/<FotografiasController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (_context.Fotografias is null)
            {
                return NotFound();
            }

            var fotografia = await _context.Fotografias.FirstOrDefaultAsync(c => c.IDfotografia == id);
            if (fotografia == null)
            {
                return NotFound();
            }

            _context.Fotografias.Remove(fotografia);
            await _context.SaveChangesAsync();
            return NoContent();

        }
    }

}