#nullable disable
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Destino_Certo.Data;
using Destino_Certo.Models;
using Destino_Certo.Data.Dtos.Destino;
using AutoMapper;

namespace Destino_Certo.Controllers
{
    public class DestinoController : Controller
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public DestinoController(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IActionResult> Locais()
        {
            var destinos = await _context.Destinos.ToListAsync();
            List<string> vs = new List<string>();
            foreach (var item in destinos)
            {
                string Base64 = Convert.ToBase64String(item.ArrayImagem);
                string img = String.Format("data:image/jpeg;base64,{0}", Base64);
                item.ExtensaoArquivo = img;
            }
            return View(destinos);



            //return View(await _context.Destinos.ToListAsync());
        }

        // GET: Destino
        public async Task<IActionResult> Index()
        {
            var destinos = await _context.Destinos.ToListAsync();
            List<string> vs = new List<string>();
            foreach (var item in destinos)
            {
                string Base64 = Convert.ToBase64String(item.ArrayImagem);
                string img = String.Format("data:image/jpeg;base64,{0}", Base64);
                item.ExtensaoArquivo = img;
            }
            return View(destinos);
            
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var destinoModel = await _context.Destinos
                .FirstOrDefaultAsync(m => m.Id == id);
                string Base64 = Convert.ToBase64String(destinoModel.ArrayImagem);
                string img = String.Format("data:image/jpeg;base64,{0}", Base64);
                destinoModel.ExtensaoArquivo = img;

            if (destinoModel == null)
            {
                return NotFound();
            }

            return View(destinoModel);
        }

        // GET: Destino/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Destino/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Local,Imagem,Descricao,Incluso")] CreateDestinoDto destinoModel, IFormFile formFile)
        {
            
            var memoryStream = new MemoryStream();
            await formFile.CopyToAsync(memoryStream);

            var file = destinoModel.ArrayImagem;
            var Content = memoryStream.ToArray();
            destinoModel.NomeArquivo = formFile.FileName;
            destinoModel.ExtensaoArquivo = formFile.ContentType;
            destinoModel.InfoArquivo = $"{Convert.ToString(formFile.Length)} bytes";
            destinoModel.ArrayImagem = Content;
            //string Image = Convert.ToBase64String(Content);
            DestinoModel destinoM = _mapper.Map<DestinoModel>(destinoModel);

            
            _context.Add(destinoM);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
        }

        // GET: Destino/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var destinoModel = await _context.Destinos.FindAsync(id);
            if (destinoModel == null)
            {
                return NotFound();
            }
            return View(destinoModel);
        }

        // POST: Destino/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Local,Imagem,Descricao,Incluso")] DestinoModel destinoModel)
        {
            if (id != destinoModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(destinoModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DestinoModelExists(destinoModel.Id))
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
            return View(destinoModel);
        }

        // GET: Destino/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var destinoModel = await _context.Destinos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (destinoModel == null)
            {
                return NotFound();
            }

            return View(destinoModel);
        }

        // POST: Destino/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var destinoModel = await _context.Destinos.FindAsync(id);
            _context.Destinos.Remove(destinoModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DestinoModelExists(int id)
        {
            return _context.Destinos.Any(e => e.Id == id);
        }

    }
}
