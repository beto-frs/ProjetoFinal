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

namespace Destino_Certo.Controllers
{
    public class ReservaController : Controller
    {
        private readonly Context _context;

        public ReservaController(Context context)
        {
            _context = context;
        }

        // GET: Reserva
        public async Task<IActionResult> Index()
        {
            var context = _context.Reservas.Include(r => r.Destino).Include(r => r.Pessoa);
            return View(await context.ToListAsync());
        }

        // GET: Reserva/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservaModel = await _context.Reservas
                .Include(r => r.Destino)
                .Include(r => r.Pessoa)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reservaModel == null)
            {
                return NotFound();
            }

            return View(reservaModel);
        }

        // GET: Reserva/Create
        public IActionResult Create()
        {
            ViewData["DestinoId"] = new SelectList(_context.Destinos, "Id", "Local");
            //ViewData["PessoaId"] = new SelectList(_context.Pessoas, "Id", "Nome");
            ViewData["PessoaId"] = HttpContext.Session.GetString("Nome");
            return View();
        }

        // POST: Reserva/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PessoaId,DataViagem,Pacote,DestinoId,AtendimentoId,NomeAnalista,IsConfirmed,FormaPagamento")] ReservaModel reservaModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reservaModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DestinoId"] = new SelectList(_context.Destinos, "Id", "Descricao", reservaModel.DestinoId);
            ViewData["PessoaId"] = new SelectList(_context.Pessoas, "Id", "Bairro", reservaModel.PessoaId);
            return View(reservaModel);
        }

        // GET: Reserva/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservaModel = await _context.Reservas.FindAsync(id);
            if (reservaModel == null)
            {
                return NotFound();
            }
            ViewData["DestinoId"] = new SelectList(_context.Destinos, "Id", "Descricao", reservaModel.DestinoId);
            ViewData["PessoaId"] = new SelectList(_context.Pessoas, "Id", "Bairro", reservaModel.PessoaId);
            return View(reservaModel);
        }

        // POST: Reserva/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PessoaId,DataViagem,Pacote,DestinoId,AtendimentoId,NomeAnalista,IsConfirmed,FormaPagamento")] ReservaModel reservaModel)
        {
            if (id != reservaModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reservaModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservaModelExists(reservaModel.Id))
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
            ViewData["DestinoId"] = new SelectList(_context.Destinos, "Id", "Descricao", reservaModel.DestinoId);
            ViewData["PessoaId"] = new SelectList(_context.Pessoas, "Id", "Bairro", reservaModel.PessoaId);
            return View(reservaModel);
        }

        // GET: Reserva/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservaModel = await _context.Reservas
                .Include(r => r.Destino)
                .Include(r => r.Pessoa)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reservaModel == null)
            {
                return NotFound();
            }

            return View(reservaModel);
        }

        // POST: Reserva/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reservaModel = await _context.Reservas.FindAsync(id);
            _context.Reservas.Remove(reservaModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservaModelExists(int id)
        {
            return _context.Reservas.Any(e => e.Id == id);
        }
    }
}
