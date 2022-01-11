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
        private readonly Context _context;
        private readonly IMapper _mapper;

        public PessoaController(Context context, IMapper mapper, ICrypto crypto)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pessoas.ToListAsync());
        }

        [HttpGet]
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
                _context.Add(pessoa);
                await _context.SaveChangesAsync();
                string[] PrimeiroNome = pessoa.Nome.Split(" ");
                string PNome = PrimeiroNome[0];
                HttpContext.Session.SetString("Nome", PNome);
                HttpContext.Session.SetString("NomeCompleto", pessoa.Nome);
                HttpContext.Session.SetString("Login", pessoa.Login);
                HttpContext.Session.SetString("Senha", pessoa.Senha);
                HttpContext.Session.SetString("Email", pessoa.Email);
                HttpContext.Session.SetString("Telefone", pessoa.Telefone);
                HttpContext.Session.SetString("TipoConta", pessoa.TipoConta);
                ViewBag.Mensagem = "Cadastrado com sucesso";
                return RedirectToAction(nameof(Index),"Home");
            }
            ;
            return View(pessoaDto);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var pessoaModel = await _context.Pessoas.FindAsync(id);
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
                    _context.Update(pessoa);
                    await _context.SaveChangesAsync();

                }
                catch
                {

                }
                ViewBag.Mensagem = "Dados Atualizados com sucesso";
                return View();
                //return RedirectToAction(nameof(Index),"Home");
            }
            return View(pessoaDto);
        }

        [HttpGet]
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
            _context.Pessoas.Remove(pessoaModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PessoaModelExists(int id)
        {
            return _context.Pessoas.Any(e => e.Id == id);
        }
    }
}
