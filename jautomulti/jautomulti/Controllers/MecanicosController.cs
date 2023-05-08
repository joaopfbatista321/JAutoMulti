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
    public class MecanicosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MecanicosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Mecanicos
        public async Task<IActionResult> Index()
        {
              return View(await _context.Mecanics.ToListAsync());
        }

        // GET: Mecanicos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Mecanics == null)
            {
                return NotFound();
            }

            var mecanicos = await _context.Mecanics
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mecanicos == null)
            {
                return NotFound();
            }

            return View(mecanicos);
        }

        // GET: Mecanicos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Mecanicos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Alcunha,Morada,CodPostal,Email,Telemovel")] Mecanicos mecanicos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mecanicos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mecanicos);
        }

        // GET: Mecanicos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Mecanics == null)
            {
                return NotFound();
            }

            var mecanicos = await _context.Mecanics.FindAsync(id);
            if (mecanicos == null)
            {
                return NotFound();
            }
            return View(mecanicos);
        }

        // POST: Mecanicos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Alcunha,Morada,CodPostal,Email,Telemovel")] Mecanicos mecanicos)
        {
            if (id != mecanicos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mecanicos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MecanicosExists(mecanicos.Id))
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
            return View(mecanicos);
        }

        // GET: Mecanicos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Mecanics == null)
            {
                return NotFound();
            }

            var mecanicos = await _context.Mecanics
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mecanicos == null)
            {
                return NotFound();
            }

            return View(mecanicos);
        }

        // POST: Mecanicos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Mecanics == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Mecanics'  is null.");
            }
            var mecanicos = await _context.Mecanics.FindAsync(id);
            if (mecanicos != null)
            {
                _context.Mecanics.Remove(mecanicos);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MecanicosExists(int id)
        {
          return _context.Mecanics.Any(e => e.Id == id);
        }
    }
}
