using jautomulti.Data;
using jautomulti.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace jautomulti.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrosApiController : ControllerBase
    {
            private readonly ApplicationDbContext _context;

            public CarrosApiController(ApplicationDbContext context)
            {
                _context = context;
            }



            // GET: api/CarrosApi
            [HttpGet]
            public async Task<ActionResult<IEnumerable<CarrosViewModel>>> GetCarros()
            {
                return await _context.Carros
                                     .Include(a => a.Proprietario)
                                     .OrderByDescending(a => a.Id)
                                     .Select(a => new CarrosViewModel
                                     {
                                         Id = a.Id,
                                         Matricula = a.Matricula,
                                         Tipo = a.Tipo,
                                         Cor = a.Cor,
                                         Marca = a.Marca,
                                         Modelo = a.Modelo,
                                         Proprietario = a.Proprietario.Nome
                                     })
                                    .ToListAsync();
            }



            // GET: api/CarrosAPI/5
            [HttpGet("{id}")]
            public async Task<ActionResult<Carros>> GetCarros(int id)
            {
                var carros = await _context.Carros.FindAsync(id);

                if (carros == null)
                {
                    return NotFound();
                }

                return carros;
            }



            // PUT: api/CarrosAPI/5
            // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
            [HttpPut("{id}")]
            public async Task<IActionResult> PutCarros(int id, Carros carros)
            {
                if (id != carros.Id)
                {
                    return BadRequest();
                }

                _context.Entry(carros).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarrosExists(id))
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




            // POST: api/CarrosAPI
            // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
            [HttpPost]
            public async Task<ActionResult<Carros>> PostAnimais([FromForm] Carros carro, IFormFile uploadFotoCarro)
            {

                // o anotador [FromForm] informa o ASP .NET que os dados são fornecidos 
                // em FormData

                /*
                 * TAREFAS A EXECUTAR:
                 * 1. validar os dados
                 * 2. inserir a foto no disco rígido (semelhante ao feito no Veterinário)
                 * 3. usar Try-Catch
                 */


               // carro.Fotografia = "carroVazio.jpg";


                // 3.
                try
                {
                    _context.Carros.Add(carro);
                    await _context.SaveChangesAsync();
                }
                catch (Exception)
                {

                    throw;
                }


                return CreatedAtAction("GetAnimais", new { id = carro.Id }, carro);
            }




            // DELETE: api/AnimaisAPI/5
            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteCarros(int id)
            {
                var carros = await _context.Carros.FindAsync(id);
                if (carros == null)
                {
                    return NotFound();
                }

                _context.Carros.Remove(carros);
                await _context.SaveChangesAsync();

                return NoContent();
            }




            private bool CarrosExists(int id)
            {
                return _context.Carros.Any(e => e.Id == id);
            }
        }
    }