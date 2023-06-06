using jautomulti.Data;
using jautomulti.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace jautomulti.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProprietariosApiController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProprietariosApiController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET: api/ProprietariosApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProprietariosViewModel>>> GetProprietarios()
        {
            return await _context.Proprietarios
                                 .OrderBy(d => d.Nome)
                                 .Select(d => new ProprietariosViewModel
                                 {
                                     Id = d.Id,
                                     Nome = d.Nome + " (NIF: " + d.NIF + ")"
                                 })
                                 .ToListAsync();
        }








        // GET: api/ProprietariosApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Proprietarios>> GetProprietarios(int id)
        {
            var proprietarios = await _context.Proprietarios.FindAsync(id);

            if (proprietarios == null)
            {
                return NotFound();
            }

            return proprietarios;
        }

        // PUT: api/ProprietariosApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProprietarios(int id, Proprietarios proprietarios)
        {
            if (id != proprietarios.Id)
            {
                return BadRequest();
            }

            _context.Entry(proprietarios).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProprietariosExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ProprietariosApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Proprietarios>> PostProprietarios(Proprietarios proprietarios)
        {
            _context.Proprietarios.Add(proprietarios);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProprietarios", new { id = proprietarios.Id }, proprietarios);
        }

        // DELETE: api/ProprietariosApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProprietarios(int id)
        {
            var proprietarios = await _context.Proprietarios.FindAsync(id);
            if (proprietarios == null)
            {
                return NotFound();
            }

            _context.Proprietarios.Remove(proprietarios);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProprietariosExists(int id)
        {
            return _context.Proprietarios.Any(e => e.Id == id);
        }
    }
}
    

