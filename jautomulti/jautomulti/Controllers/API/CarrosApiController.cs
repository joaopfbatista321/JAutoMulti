using jautomulti.Data;
using jautomulti.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            var carros = await _context.Carros
                .Include(a => a.Proprietario)
                .Include(a => a.Fotografia)
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

            return carros;
        }

        // GET: api/CarrosApi/5
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

        // PUT: api/CarrosApi/5
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

        // POST: api/CarrosApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Carros>> PostCarros([FromForm] Carros carro, IFormFile uploadFotoCarro)
        {
            // Perform data validation and handle file upload here

            // 1. Validate the data
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // 2. Handle file upload
            if (uploadFotoCarro != null && uploadFotoCarro.Length > 0)
            {
                // Save the file to disk or perform any necessary operations
            }

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

        // DELETE: api/CarrosApi/5
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
