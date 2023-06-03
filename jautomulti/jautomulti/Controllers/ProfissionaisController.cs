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
    public class ProfissionaisController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProfissionaisController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Profissionais
        public async Task<IActionResult> Index()
        {
              return View(await _context.Profissionais.ToListAsync());
        }

        // GET: Profissionais/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Profissionais == null)
            {
                return NotFound();
            }

            var profissionais = await _context.Profissionais
                .FirstOrDefaultAsync(m => m.Id == id);
            if (profissionais == null)
            {
                return NotFound();
            }

            return View(profissionais);
        }

        // GET: Profissionais/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Profissionais/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Alcunha,Morada,CodPostal,Email,Telemovel,Especializacao")] Profissionais profissionais)
        {
            if (ModelState.IsValid)
            {
                _context.Add(profissionais);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(profissionais);
        }

        // GET: Profissionais/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Profissionais == null)
            {
                return NotFound();
            }

            var profissionais = await _context.Profissionais.FindAsync(id);
            if (profissionais == null)
            {
                return NotFound();
            }
            return View(profissionais);
        }

        // POST: Profissionais/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Alcunha,Morada,CodPostal,Email,Telemovel,Especializacao")] Profissionais profissionais)
        {
            if (id != profissionais.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(profissionais);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfissionaisExists(profissionais.Id))
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
            return View(profissionais);
        }

        // GET: Profissionais/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Profissionais == null)
            {
                return NotFound();
            }

            var profissionais = await _context.Profissionais
                .FirstOrDefaultAsync(m => m.Id == id);
            if (profissionais == null)
            {
                return NotFound();
            }

            return View(profissionais);
        }

        // POST: Profissionais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Profissionais == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Profissionais'  is null.");
            }
            var profissionais = await _context.Profissionais.FindAsync(id);
            if (profissionais != null)
            {
                _context.Profissionais.Remove(profissionais);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfissionaisExists(int id)
        {
          return _context.Profissionais.Any(e => e.Id == id);
        }
    }
}
