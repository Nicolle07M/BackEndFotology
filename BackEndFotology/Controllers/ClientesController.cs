using BackEndFotology.Data;
using BackEndFotology.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ProyectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ClientesController(ApplicationDbContext context)
        {

            this._context = context;
        }

        // GET: api/<ClientesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> Get()
        {
            if (_context.Clientes == null)
            {
                return NotFound();
            }

            return await _context.Clientes.ToListAsync();

        }

        // GET api/<SuppliersController>/5
        [HttpGet("{id}")] // Variables de ruta  https://localhost:7030/api/suppliers/5 
        public async Task<ActionResult<Cliente>> Get(int id)
        {

            if (_context.Clientes == null
)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes.FindAsync(id);

            if (cliente is null)
            {
                return NotFound();
            }

            return cliente;
        }

        // POST api/<ClienteController>
        [HttpPost]
        public async Task<ActionResult<Cliente>> Post([FromBody] Cliente cliente)
        {
            if (_context.Clientes == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Clientes'  is null.");
            }
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
            return CreatedAtAction("Get", new { id = cliente.IDcliente }, cliente);
        }

        // PUT api/<CustomersController>/5
        // PUT api/customers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Cliente cliente)
        {

            if (id != cliente.IDcliente)
            {
                return BadRequest();
            }
            _context.Entry(cliente).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

                if (!ClientesExists(id))
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

        private bool ClientesExists(int id)
        {
            return (_context.Clientes?.Any(c => c.IDcliente == id)).GetValueOrDefault();
        }


        // DELETE api/<CustomersController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (_context.Clientes is null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes.FirstOrDefaultAsync(c => c.IDcliente == id);
            if (cliente == null)
            {
                return NotFound();
            }

            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
            return NoContent();

        }
    }

}
