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
using Destino_Certo.Crypto;
using Destino_Certo.Data.Dtos;
using Destino_Certo.Data.Dtos.Atendimento;

namespace Destino_Certo.Controllers
{
    public class AtendimentoController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICrypto _crypto;

        public AtendimentoController(AppDbContext context, IMapper mapper, ICrypto crypto)
        {
            _context = context;
            _mapper = mapper;
            _crypto = crypto;
        }

        // GET: Atendimento
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Atendimentos.Include(a => a.Pessoa);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Atendimento/Details/5
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

        // GET: Atendimento/Create
        public IActionResult Create()
        {
            ViewData["PessoaModelId"] = new SelectList(_context.Pessoas, "Id", "Nome");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateAtendimentoDto atendimentoDto)
        {
            if (ModelState.IsValid)
            {
                AtendimentoModel atendimento = _mapper.Map<AtendimentoModel>(atendimentoDto);
                _context.Add(atendimento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(atendimentoDto);
        }

        // GET: Atendimento/Edit/5
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

        // POST: Atendimento/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Assunto,PessoaModelId,Mensagem,Inicio,Termino,Tratativa,AnalistaId")] AtendimentoModel atendimentoModel)
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

        // GET: Atendimento/Delete/5
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

        // POST: Atendimento/Delete/5
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
