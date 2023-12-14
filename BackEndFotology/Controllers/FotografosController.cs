using BackEndFotology.Data;
using BackEndFotology.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ProyectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FotografosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FotografosController(ApplicationDbContext context)
        {

            this._context = context;
        }

        // GET: api/<CustomersController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fotografo>>> Get()
        {
            if (_context.Fotografos == null)
            {
                return NotFound();
            }

            return await _context.Fotografos.ToListAsync();

        }

        // GET api/<SuppliersController>/5
        [HttpGet("{id}")] // Variables de ruta  https://localhost:7030/api/suppliers/5 
        public async Task<ActionResult<Fotografo>> Get(int id)
        {

            if (_context.Fotografos == null
)
            {
                return NotFound();
            }

            var fotografo = await _context.Fotografos.FindAsync(id);

            if (fotografo is null)
            {
                return NotFound();
            }

            return fotografo;
        }

        // POST api/<CustomersController>
        [HttpPost]
        public async Task<ActionResult<Fotografo>> Post([FromBody] Fotografo fotografo)
        {
            if (_context.Fotografos == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Fotografos'  is null.");
            }
            _context.Fotografos.Add(fotografo);
            await _context.SaveChangesAsync();
            return CreatedAtAction("Get", new { id = fotografo.IDfotografo }, fotografo);
        }

        // PUT api/<CustomersController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Fotografo fotografo)
        {

            if (id != fotografo.IDfotografo)
            {
                return BadRequest();
            }
            _context.Entry(fotografo).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

                if (!FotografosExists(id))
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

        private bool FotografosExists(int id)
        {
            return (_context.Fotografos?.Any(c => c.IDfotografo == id)).GetValueOrDefault();
        }


        // DELETE api/<CustomersController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (_context.Fotografos is null)
            {
                return NotFound();
            }

            var fotografo = await _context.Fotografos.FirstOrDefaultAsync(c => c.IDfotografo == id);
            if (fotografo == null)
            {
                return NotFound();
            }

            _context.Fotografos.Remove(fotografo);
            await _context.SaveChangesAsync();
            return NoContent();

        }
    }
    
}