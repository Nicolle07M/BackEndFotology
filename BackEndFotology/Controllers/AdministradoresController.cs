using BackEndFotology.Data;
using BackEndFotology.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;

namespace ProyectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministradoresController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AdministradoresController(ApplicationDbContext context)
        {

            this._context = context;
        }

        // GET: api/<CustomersController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Administrador>>> Get()
        {
            if (_context.Administradores == null)
            {
                return NotFound();
            }

            return await _context.Administradores.ToListAsync();

        }

        // GET api/<SuppliersController>/5
        [HttpGet("{id}")] // Variables de ruta  https://localhost:7030/api/suppliers/5 
        public async Task<ActionResult<Administrador>> Get(int id)
        {

            if (_context.Administradores == null
)
            {
                return NotFound();
            }

            var administrador = await _context.Administradores.FindAsync(id);

            if (administrador is null)
            {
                return NotFound();
            }

            return administrador;
        }

        // POST api/<CustomersController>
        [HttpPost]
        public async Task<ActionResult<Administrador>> Post([FromBody] Administrador administrador)
        {
            if (_context.Administradores == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Administradores'  is null.");
            }
            _context.Administradores.Add(administrador);
            await _context.SaveChangesAsync();
            return CreatedAtAction("Get", new { id = administrador.IDadministrador }, administrador);
        }

        // PUT api/<CustomersController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Administrador administrador)
        {
            if (id != administrador.IDadministrador)
            {
                return BadRequest();
            }

            try
            {
                _context.Attach(administrador);
                _context.Entry(administrador).State = (Microsoft.EntityFrameworkCore.EntityState)System.Data.Entity.EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!AdministradoresExists(id))
                {
                    return NotFound();
                }
                else
                {
                    // Log or print the exception details for further analysis
                    Console.WriteLine(ex.Message);
                    return BadRequest();
                }
            }

            return NoContent();
        }


        private bool AdministradoresExists(int id)
        {
            return (_context.Administradores?.Any(c => c.IDadministrador == id)).GetValueOrDefault();
        }


        // DELETE api/<CustomersController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (_context.Administradores is null)
            {
                return NotFound();
            }

            var administrador = await _context.Administradores.FirstOrDefaultAsync(c => c.IDadministrador == id);
            if (administrador == null)
            {
                return NotFound();
            }

            _context.Administradores.Remove(administrador);
            await _context.SaveChangesAsync();
            return NoContent();

        }
    }
}