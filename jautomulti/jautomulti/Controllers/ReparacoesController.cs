﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using jautomulti.Data;
using jautomulti.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace jautomulti.Controllers
{
    [Authorize(Roles = "Profissional,Admin")]
    public class ReparacoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReparacoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Reparacoes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Reparacoes.Include(r => r.Carro).Include(r => r.ListaProfissionaisNaReparacao);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Reparacoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Reparacoes == null)
            {
                return NotFound();
            }

            var reparacoes = await _context.Reparacoes
                .Include(r => r.Carro)
                .Include(r => r.ListaProfissionaisNaReparacao)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reparacoes == null)
            {
                return NotFound();
            }

            return View(reparacoes);
        }

        // GET: Reparacoes/Create
        public IActionResult Create()
        {

            ViewData["CarroFK"] = new SelectList(_context.Carros, "Id", "Matricula");
            ViewData["ListaProfissionaisNaReparacao"] = new SelectList(_context.Profissionais, "Id", "Nome");
            return View();
        }

        // POST: Reparacoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DataInicio,DataFim,Observacoes,AuxPreco,Preco,CarroFK,ListaProfissionaisNaReparacao")] Reparacoes reparacoes)
        {
            // atribuir o valor do PrecoCompraAux, se existir,
            // ao atributo PrecoCompra
            if (!string.IsNullOrEmpty(reparacoes.AuxPreco))
            {
                reparacoes.Preco = Convert.ToDecimal(reparacoes.AuxPreco.Replace('.', ','));
            }

            if (ModelState.IsValid)
            {
                _context.Add(reparacoes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarroFK"] = new SelectList(_context.Carros, "Id", "Matricula", reparacoes.CarroFK);
            ViewData["ListaProfissionaisNaReparacao"] = new SelectList(_context.Profissionais, "Id", "Nome", reparacoes.ListaProfissionaisNaReparacao);
            return View(reparacoes);
        }

        // GET: Reparacoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Reparacoes == null)
            {
                return NotFound();
            }

            var reparacoes = await _context.Reparacoes.FindAsync(id);
            if (reparacoes == null)
            {
                return NotFound();
            }
            ViewData["CarroFK"] = new SelectList(_context.Carros, "Id", "Matricula", reparacoes.CarroFK);
            ViewData["ListaProfissionaisNaReparacao"] = new SelectList(_context.Profissionais, "Id", "Nome", reparacoes.ListaProfissionaisNaReparacao);
           
            return View(reparacoes);
            
        }

        // POST: Reparacoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DataInicio,DataFim,Observacoes,Preco,AuxPreco,CarroFK,ListaProfissionaisNaReparacao")] Reparacoes reparacoes)
        {
            // atribuir o valor do PrecoCompraAux, se existir,
            // ao atributo PrecoCompra
            if (!string.IsNullOrEmpty(reparacoes.AuxPreco))
            {
                reparacoes.Preco = Convert.ToDecimal(reparacoes.AuxPreco.Replace('.', ','));
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reparacoes);
                  

                   
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReparacoesExists(reparacoes.Id))
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
            ViewData["CarroFK"] = new SelectList(_context.Carros, "Id", "Matricula", reparacoes.CarroFK);
            ViewData["ListaProfissionaisNaReparacao"] = new SelectList(_context.Profissionais, "Id", "Nome", reparacoes.ListaProfissionaisNaReparacao);
           

            // Load the available professionals
           // ViewData["Profissionais"] = new MultiSelectList(_context.Profissionais, "Id", "Nome", reparacoes.ListaProfissionaisNaReparacao);
            return View(reparacoes);
        }

        // GET: Reparacoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Reparacoes == null)
            {
                return NotFound();
            }

            var reparacoes = await _context.Reparacoes
                .Include(r => r.Carro)
                .Include(r => r.ListaProfissionaisNaReparacao)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reparacoes == null)
            {
                return NotFound();
            }

            return View(reparacoes);
        }

        // POST: Reparacoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
           
            var reparacoes = await _context.Reparacoes.FindAsync(id);
            if (reparacoes != null)
            {
                _context.Reparacoes.Remove(reparacoes);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReparacoesExists(int id)
        {
          return _context.Reparacoes.Any(e => e.Id == id);
        }
    }
}
