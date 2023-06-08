using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using jautomulti.Data;
using jautomulti.Models;

namespace jautomulti.Controllers
{
    public class CarrosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CarrosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Carros
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Carros.Include(c => c.Proprietario);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Carros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Carros == null)
            {
                return NotFound();
            }

            var carros = await _context.Carros
                .Include(c => c.Proprietario)
                .Include(c => c.ListaReparacoes)
                
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carros == null)
            {
                return NotFound();
            }

            return View(carros);
        }

        // GET: Carros/Create
        public IActionResult Create()
        {
            ViewData["ProprietarioFK"] = new SelectList(_context.Proprietarios, "Id", "Nome");
            return View();
        }

        // POST: Carros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,VIN,DataMatricula,DataCompra,Tipo,Matricula,Marca,Modelo,Cor,ProprietarioFK")] Carros carros)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carros);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProprietarioFK"] = new SelectList(_context.Proprietarios, "Id", "Nome", carros.ProprietarioFK);
            return View(carros);
           
        }

        // GET: Carros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Carros == null)
            {
                return NotFound();
            }

            var carros = await _context.Carros.FindAsync(id);
            if (carros == null)
            {
                return NotFound();
            }
            ViewData["ProprietarioFK"] = new SelectList(_context.Proprietarios, "Id", "Nome", carros.ProprietarioFK);
            return View(carros);
        }

        // POST: Carros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,VIN,DataMatricula,DataCompra,Tipo,Matricula,Marca,Modelo,Cor,ProprietarioFK")] Carros carros)
        {
            if (id != carros.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carros);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarrosExists(carros.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProprietarioFK"] = new SelectList(_context.Proprietarios, "Id", "Nome", carros.ProprietarioFK);
            return View(carros);
        }

        // GET: Carros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Carros == null)
            {
                return NotFound();
            }

            var carros = await _context.Carros
                .Include(c => c.Proprietario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carros == null)
            {
                return NotFound();
            }

            return View(carros);
        }

        // POST: Carros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Carros == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Carros'  is null.");
            }
            var carros = await _context.Carros.FindAsync(id);
            if (carros != null)
            {
                _context.Carros.Remove(carros);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarrosExists(int id)
        {
          return _context.Carros.Any(e => e.Id == id);
        }
    }
}
