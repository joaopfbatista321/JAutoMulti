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
    [Authorize]
    public class CarrosController : Controller
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Este recurso (tecnicamente, um atributo) mostra os 
        /// dados do servidor. 
        /// É necessário inicializar este atributo no construtor da classe
        /// </summary>
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CarrosController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Carros
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Carros.Include(c => c.Proprietario).Include(c => c.ListaReparacoes);
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
                .Include(c => c.Fotografia)
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
        public async Task<IActionResult> Create([Bind("Id,VIN,DataMatricula,DataCompra,Tipo,Matricula,Marca,Modelo,Cor,ProprietarioFK")] Carros carros, IFormFile fotografiaCarro)
        {
            /*
         * qd se adiciona um novo atributo ao Modelo,
         * É NECESSÁRIO adicionar esse atrributo ao Bind.
         * Se não for feito, o seu valor será descartado
         */



            // vars. auxiliares
            string nomeFoto = "";
            bool existeFoto = false;

            // validação do Proprietario
            if (carros.ProprietarioFK == 0)
            {
                ModelState.AddModelError("", "É necessário escolher o Proprietario do Carro.");
            }
            else
            {
                // existe foto? é válida?
                if (fotografiaCarro == null)
                {
                    // não há foto.
                    // adiciona-se a foto prédefinida
                    carros.Fotografia
                          .Add(new Fotografias
                          {
                              DataFotografia = DateTime.Now,
                              Local = "NoImage",
                              NomeFicheiro = "noCar.jpeg"
                          });
                }
                else
                {
                    // há ficheiro.
                    // Mas, será válido?
                    if (fotografiaCarro.ContentType == "image/jpeg" ||
                       fotografiaCarro.ContentType == "image/png")
                    {
                        // imagem válida
                        // https://developer.mozilla.org/en-US/docs/Web/HTTP/Basics_of_HTTP/MIME_types
                        // vamos processar a imagem
                        carros.Fotografia.Add(new Fotografias { DataFotografia = DateTime.Now, Local = "noImage", NomeFicheiro = "noCar.jpeg" });

                    }
                    else
                    {
                        // definir o nome da imagem
                        Guid g = Guid.NewGuid();
                        nomeFoto = g.ToString();
                        string extensaoDaFoto = Path.GetExtension(fotografiaCarro.FileName).ToLower();
                        nomeFoto += extensaoDaFoto;
                        // adiciona-se a foto à lista de fotografias
                        carros.Fotografia.Add(new Fotografias
                        {
                            DataFotografia = DateTime.Now,
                            Local = "",
                            NomeFicheiro = nomeFoto
                        });
                        // preparar a foto para ser guardada
                        // no disco rígido do servidor
                        existeFoto = true;
                    }

                }//Pro
            }
                if (ModelState.IsValid)
                {
                    _context.Add(carros);
                    await _context.SaveChangesAsync();

                    // agora já posso guardar a imagem no disco 
                    // rígido do servidor
                    if (existeFoto)
                    {
                        // definir o locar onde a foto vai ser guardada
                        // para isso vamos perguntar ao servidor onde está 
                        // a pasta wwwroot/imagens
                        string nomeLocalizacaoImagem = _webHostEnvironment.WebRootPath;

                        //    - falta definir o nome que o ficheiro vai ter no disco rígido
                        nomeLocalizacaoImagem =
                           Path.Combine(nomeLocalizacaoImagem, "imagens");

                        //    - falta garantir que a pasta onde se vai guardar o ficheiro existe
                        if (!Directory.Exists(nomeLocalizacaoImagem))
                        {
                            Directory.CreateDirectory(nomeLocalizacaoImagem);
                        }

                        //    - agora já é possível guardar a imagem
                        //         - definir o nome da imagem no disco rígido
                        string nomeFotoImagem = Path.Combine(nomeLocalizacaoImagem, nomeFoto);

                        //         - criar objeto para manipular a imagem
                        using var stream = new FileStream(nomeFotoImagem, FileMode.Create);

                        //         - guardar, realmente, o ficheiro no disco rígido
                        await fotografiaCarro.CopyToAsync(stream);
                    }




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
