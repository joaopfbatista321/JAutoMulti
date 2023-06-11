using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using jautomulti.Data;
using jautomulti.Models;
using Microsoft.AspNetCore.Authorization;

namespace jautomulti.Controllers
{
    /* [Authorize(Roles = "Profissional")]  -->  apenas os utilizadores deste tipo
*                                          têm acesso
*                                          
* [Authorize(Roles = "Profissional,Admin")]  --> utilizadores dos tipos
*                                                        Profissional
*                                                        OU
*                                                        Administrativo
*                                                        têm acesso às funcionalidades
*
* [Authorize(Roles = "Profissional")]
* [Authorize(Roles = "Admin")]  --> têm acessos os utilizadores dos perfis
*                                            Profissional
*                                            E
*                                            Administrativo
*/
   [Authorize(Roles = "Profissional,Admin")]
    public class ProfissionaisController : Controller
    {
    


        /// <summary>
        /// cria uma instancia de acesso à Base de Dados
        /// </summary>
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// esta variável vai conter os dados do servidor
        /// </summary>
        private readonly IWebHostEnvironment _webHostEnvironment;


        public ProfissionaisController(ApplicationDbContext context,
         IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Profissionais
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            /* acesso à base de dados
        * SELECT *
        * FROM Proprietarios
        * 
        * e, depois estamos a enviar os dados para a View
        */
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

        //// GET: Profissionais/Create
        ///// <summary>
        ///// usado para o primeiro acesso à View 'Create', em modo HTTP GET
        ///// </summary>
        ///// <returns></returns>
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Profissionais/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        ///// <summary>
        ///// método usado para recuperar os dados enviados pelos utilizadores, 
        ///// do Browser para o servidor
        ///// </summary>
        ///// <param name="profissionais"></param>
        ///// <returns></returns>
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Nome,Alcunha,Morada,CodPostal,Email,Telemovel,Especializacao")] Profissionais profissionais)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(profissionais);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(profissionais);
        //}

        //// GET: Profissionais/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null || _context.Profissionais == null)
        //    {
        //        return NotFound();
        //    }

        //    var profissionais = await _context.Profissionais.FindAsync(id);
        //    if (profissionais == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(profissionais);
        //}

        // POST: Profissionais/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Sexo,NIF,Alcunha,Morada,CodPostal,Email,Telemovel,Especializacao")] Profissionais profissionais)
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
