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
using Destino_Certo.Data.Dtos;
using Destino_Certo.Crypto;
using Destino_Certo.Data.Dtos.Pessoa;

namespace Destino_Certo.Controllers
{
    public class PessoaController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICrypto _crypto;

        public PessoaController(AppDbContext context, IMapper mapper, ICrypto crypto)
        {
            _context = context;
            _mapper = mapper;
            _crypto = crypto;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Pessoas.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoa = await _context.Pessoas.FirstOrDefaultAsync(m => m.Id == id);
            if (pessoa == null)
            {
                return NotFound();
            }

            return View(pessoa);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreatePessoaDto pessoaDto)
        {
            if (ModelState.IsValid)
            {
                PessoaModel pessoa = _mapper.Map<PessoaModel>(pessoaDto);
                pessoa.Usuario.Senha = _crypto.Encrypt(pessoaDto.Usuario.Senha);
                _context.Add(pessoa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pessoaDto);
        }

        public async Task<IActionResult> Edit(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var pessoaModel = await _context.Pessoas.FindAsync(id);
            pessoaModel.Usuario.Senha = _crypto.Decrypt(pessoaModel.Usuario.Senha);
            if (pessoaModel == null)
            {
                return NotFound();
            }
            PessoaModel pessoa = _mapper.Map<PessoaModel>(pessoaModel);
            return View(pessoa);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UpdatePessoaDto pessoaDto)
        {
            var pessoa = await _context.Pessoas.FindAsync(id);

            if (ModelState.IsValid)
            {
                try
                {
                    _mapper.Map(pessoaDto, pessoa);
                    pessoa.Usuario.Senha = _crypto.Encrypt(pessoaDto.Usuario.Senha);
                    _context.Update(pessoa);
                    await _context.SaveChangesAsync();

                }
                catch
                {
                    
                }
                return RedirectToAction(nameof(Index));
            }
            return View(pessoaDto);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoaModel = await _context.Pessoas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pessoaModel == null)
            {
                return NotFound();
            }

            return View(pessoaModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pessoaModel = await _context.Pessoas.FindAsync(id);
            var usuarioModel = await _context.Usuarios.FindAsync(pessoaModel.UsuarioId);
            _context.Pessoas.Remove(pessoaModel);
            _context.Usuarios.Remove(usuarioModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PessoaModelExists(int id)
        {
            return _context.Pessoas.Any(e => e.Id == id);
        }
    }
}
