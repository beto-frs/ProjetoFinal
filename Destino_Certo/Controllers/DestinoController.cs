#nullable disable
using System;
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
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public DestinoController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: Destino
        public async Task<IActionResult> Index()
        {
            return View(await _context.Destinos.ToListAsync());
        }

        // GET: Destino/Details/5
        public async Task<IActionResult> Details(int? id)
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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateDestinoDto destinoDto)
        {
            if (ModelState.IsValid)
            {
                DestinoModel destino = _mapper.Map<DestinoModel>(destinoDto);
                _context.Add(destino);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(destinoDto);
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Imagem,Descricao")] DestinoModel destinoModel)
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
