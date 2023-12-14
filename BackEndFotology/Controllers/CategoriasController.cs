using BackEndFotology.Data;
using BackEndFotology.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace ProyectApi.Controllers
    {
        [Route("api/[controller]")]
        [ApiController]
        public class CategoriasController : ControllerBase
        {
            private readonly ApplicationDbContext _context;

            public CategoriasController(ApplicationDbContext context)
            {

                this._context = context;
            }

            // GET: api/<CustomersController>
            [HttpGet]
            public async Task<ActionResult<IEnumerable<Categoria>>> Get()
            {
                if (_context.Categorias == null)
                {
                    return NotFound();
                }

                return await _context.Categorias.ToListAsync();

            }

            // GET api/<SuppliersController>/5
            [HttpGet("{id}")] // Variables de ruta  https://localhost:7030/api/suppliers/5 
            public async Task<ActionResult<Categoria>> Get(int id)
            {

                if (_context.Categorias == null
    )
                {
                    return NotFound();
                }

                var categoria = await _context.Categorias.FindAsync(id);

                if (categoria is null)
                {
                    return NotFound();
                }

                return categoria;
            }

            // POST api/<CustomersController>
            [HttpPost]
            public async Task<ActionResult<Categoria>> Post([FromBody] Categoria categoria)
            {
                if (_context.Categorias == null)
                {
                    return Problem("Entity set 'ApplicationDbContext.Categorias'  is null.");
                }
                _context.Categorias.Add(categoria);
                await _context.SaveChangesAsync();
                return CreatedAtAction("Get", new { id = categoria.IDcategoria }, categoria);
            }

        // PUT api/<CustomersController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Categoria categoria)
        {

            if (id != categoria.IDcategoria)
            {
                return BadRequest();
            }
            _context.Entry(categoria).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

                if (!CategoriasExists(id))
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

        private bool CategoriasExists(int id)
        {
            return (_context.Categorias?.Any(c => c.IDcategoria == id)).GetValueOrDefault();
        }


        // DELETE api/<CustomersController>/5
        [HttpDelete("{id}")]
            public async Task<IActionResult> Delete(int id)
            {
                if (_context.Categorias is null)
                {
                    return NotFound();
                }

                var categoria = await _context.Categorias.FirstOrDefaultAsync(c => c.IDcategoria == id);
                if (categoria == null)
                {
                    return NotFound();
                }

                _context.Categorias.Remove(categoria);
                await _context.SaveChangesAsync();
                return NoContent();

            }
        }
    }

