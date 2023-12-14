using BackEndFotology.Data;
using BackEndFotology.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ProyectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortafoliosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PortafoliosController(ApplicationDbContext context)
        {

            this._context = context;
        }

        // GET: api/<CustomersController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Portafolio>>> Get()
        {
            if (_context.Portafolios == null)
            {
                return NotFound();
            }

            return await _context.Portafolios.ToListAsync();

        }

        // GET api/<SuppliersController>/5
        [HttpGet("{id}")] // Variables de ruta  https://localhost:7030/api/suppliers/5 
        public async Task<ActionResult<Portafolio>> Get(int id)
        {

            if (_context.Portafolios == null
)
            {
                return NotFound();
            }

            var portafolio = await _context.Portafolios.FindAsync(id);

            if (portafolio is null)
            {
                return NotFound();
            }

            return portafolio;
        }

        // POST api/<CustomersController>
        [HttpPost]
        public async Task<ActionResult<Portafolio>> Post([FromBody] Portafolio portafolio)
        {
            if (_context.Portafolios == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Portafolios'  is null.");
            }
            _context.Portafolios.Add(portafolio);
            await _context.SaveChangesAsync();
            return CreatedAtAction("Get", new { id = portafolio.IDportafolio }, portafolio);
        }

        // PUT api/<CustomersController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Portafolio portafolio)
        {

            if (id != portafolio.IDportafolio)
            {
                return BadRequest();
            }
            _context.Entry(portafolio).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

                if (!PortafoliosExists(id))
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

        private bool PortafoliosExists(int id)
        {
            return (_context.Portafolios?.Any(c => c.IDportafolio == id)).GetValueOrDefault();
        }


        // DELETE api/<CustomersController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (_context.Portafolios is null)
            {
                return NotFound();
            }

            var portafolio = await _context.Portafolios.FirstOrDefaultAsync(c => c.IDportafolio == id);
            if (portafolio == null)
            {
                return NotFound();
            }

            _context.Portafolios.Remove(portafolio);
            await _context.SaveChangesAsync();
            return NoContent();

        }
    }

}