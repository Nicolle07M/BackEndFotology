using BackEndFotology.Data;
using BackEndFotology.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ProyectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalificacionesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CalificacionesController(ApplicationDbContext context)
        {

            this._context = context;
        }

        // GET: api/<ClientesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Calificacion>>> Get()
        {
            if (_context.Calificaciones == null)
            {
                return NotFound();
            }

            return await _context.Calificaciones.ToListAsync();

        }

        // GET api/<SuppliersController>/5
        [HttpGet("{id}")] // Variables de ruta  https://localhost:7030/api/calificaciones/5 
        public async Task<ActionResult<Calificacion>> Get(int id)
        {

            if (_context.Calificaciones == null
)
            {
                return NotFound();
            }

            var calificacion = await _context.Calificaciones.FindAsync(id);

            if (calificacion is null)
            {
                return NotFound();
            }

            return calificacion;
        }

        // POST api/<ClienteController>
        [HttpPost]
        public async Task<ActionResult<Calificacion>> Post([FromBody] Calificacion calificacion)
        {
            if (_context.Calificaciones == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Calificaciones'  is null.");
            }
            _context.Calificaciones.Add(calificacion);
            await _context.SaveChangesAsync();
            return CreatedAtAction("Get", new { id = calificacion.IDcalificacion }, calificacion);
        }

        // PUT api/<CustomersController>/5
        // PUT api/customers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Calificacion calificacion)
        {

            if (id != calificacion.IDcalificacion)
            {
                return BadRequest();
            }
            _context.Entry(calificacion).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

                if (!CalificacionesExists(id))
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

        private bool CalificacionesExists(int id)
        {
            return (_context.Calificaciones?.Any(c => c.IDcalificacion == id)).GetValueOrDefault();
        }


        // DELETE api/<CustomersController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (_context.Calificaciones is null)
            {
                return NotFound();
            }

            var calificacion = await _context.Calificaciones.FirstOrDefaultAsync(c => c.IDcalificacion == id);
            if (calificacion == null)
            {
                return NotFound();
            }

            _context.Calificaciones.Remove(calificacion);
            await _context.SaveChangesAsync();
            return NoContent();

        }
    }

}
