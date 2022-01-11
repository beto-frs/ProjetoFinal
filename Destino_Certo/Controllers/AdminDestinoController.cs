﻿#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Destino_Certo.Data;
using Destino_Certo.Models;
using AutoMapper;

namespace Destino_Certo.Controllers
{
    public class AdminDestinoController : Controller
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public AdminDestinoController(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: AdminDestino
        public async Task<IActionResult> Index()
        {
            return View(await _context.Destinos.ToListAsync());
        }

        // GET: AdminDestino/Details/5
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

        // GET: AdminDestino/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdminDestino/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Local,Descricao,Incluso,NomeArquivo,ExtensaoArquivo,ArrayImagem,InfoArquivo")] DestinoModel destinoModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(destinoModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(destinoModel);
        }

        // GET: AdminDestino/Edit/5
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

        // POST: AdminDestino/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Local,Descricao,Incluso,NomeArquivo,ExtensaoArquivo,ArrayImagem,InfoArquivo")] DestinoModel destinoModel)
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

        // GET: AdminDestino/Delete/5
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

        // POST: AdminDestino/Delete/5
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