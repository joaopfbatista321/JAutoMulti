// Licencie to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using jautomulti.Data;
using jautomulti.Models;

namespace jautomulti.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrosAPIController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CarrosAPIController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/CarrosAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarrosViewModel>>> GetCarros()
        {
            var carros = await _context.Carros
                .Include(c => c.Proprietario)
                //.Include(c => c.Fotografias)
                .OrderByDescending(c => c.Id)
                .Select(c => new CarrosViewModel
                {
                    Id = c.Id,
                    Matricula = c.Matricula,
                    Tipo = c.Tipo,
                    Cor = c.Cor,
                    Marca = c.Marca,
                    Modelo = c.Modelo,
                    //Fotografia = c.Fotografias,
                    Proprietario = c.Proprietario.Nome
                })
                .ToListAsync();

            return carros;
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
        public async Task<ActionResult<Carros>> PostCarros([FromForm] Carros carro, IFormFile uploadFotoCarro)
        {
            // o anotador [FromForm] informa o ASP .NET que os dados são fornecidos 
            // em FormData

            /*
             * TAREFAS A EXECUTAR:
             * 1. validar os dados
             * 2. inserir a foto no disco rígido (semelhante ao feito no Veterinário)
             * 3. usar Try-Catch
             */


           // carro.Fotografias = "noVet.jpg";


            try
            {
                _context.Carros.Add(carro);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }

            return CreatedAtAction("GetCarros", new { id = carro.Id }, carro);
        }

        // DELETE: api/CarrosAPI/5
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
