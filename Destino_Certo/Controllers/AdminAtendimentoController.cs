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
using AutoMapper;

namespace Destino_Certo.Controllers
{
    public class AdminAtendimentoController : Controller
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public AdminAtendimentoController(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: AdminAtendimento
        public async Task<IActionResult> Index()
        {
            var context = _context.Atendimentos.Include(a => a.Pessoa);
            return View(await context.ToListAsync());
        }

        // GET: AdminAtendimento/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var atendimentoModel = await _context.Atendimentos
                .Include(a => a.Pessoa)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (atendimentoModel == null)
            {
                return NotFound();
            }

            return View(atendimentoModel);
        }

        // GET: AdminAtendimento/Create
        public IActionResult Create()
        {
            ViewData["PessoaModelId"] = new SelectList(_context.Pessoas, "Id", "Bairro");
            return View();
        }

        // POST: AdminAtendimento/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Assunto,PessoaModelId,Mensagem,Inicio,Termino,Tratativa")] AtendimentoModel atendimentoModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(atendimentoModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PessoaModelId"] = new SelectList(_context.Pessoas, "Id", "Bairro", atendimentoModel.PessoaModelId);
            return View(atendimentoModel);
        }

        // GET: AdminAtendimento/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var atendimentoModel = await _context.Atendimentos.FindAsync(id);
            if (atendimentoModel == null)
            {
                return NotFound();
            }
            ViewData["PessoaModelId"] = new SelectList(_context.Pessoas, "Id", "Bairro", atendimentoModel.PessoaModelId);
            return View(atendimentoModel);
        }

        // POST: AdminAtendimento/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Assunto,PessoaModelId,Mensagem,Inicio,Termino,Tratativa")] AtendimentoModel atendimentoModel)
        {
            if (id != atendimentoModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(atendimentoModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AtendimentoModelExists(atendimentoModel.Id))
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
            ViewData["PessoaModelId"] = new SelectList(_context.Pessoas, "Id", "Bairro", atendimentoModel.PessoaModelId);
            return View(atendimentoModel);
        }

        // GET: AdminAtendimento/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var atendimentoModel = await _context.Atendimentos
                .Include(a => a.Pessoa)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (atendimentoModel == null)
            {
                return NotFound();
            }

            return View(atendimentoModel);
        }

        // POST: AdminAtendimento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var atendimentoModel = await _context.Atendimentos.FindAsync(id);
            _context.Atendimentos.Remove(atendimentoModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AtendimentoModelExists(int id)
        {
            return _context.Atendimentos.Any(e => e.Id == id);
        }
    }
}
