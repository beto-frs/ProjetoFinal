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
using System.Text.RegularExpressions;
using System.Globalization;
namespace Destino_Certo.Controllers
{
    public class AdminController : Controller
    {
        private readonly Context _context;
        private readonly IMapper _mapper;
       

        public AdminController(Context context, IMapper mapper, ICrypto crypto)
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
            var pessoaModel = await _context.Pessoas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pessoaModel == null)
            {
                return NotFound();
            }

            return View(pessoaModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PessoaModel pessoaModel)
        {
            pessoaModel.Nome = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(pessoaModel.Nome.ToLower());

            string[] NomeEmail = pessoaModel.Nome.Split(" ");
            string emailNormalizado;
            
            if (NomeEmail.Length > 1)
            {
                 emailNormalizado = $"{CultureInfo.CurrentCulture.TextInfo.ToLower(NomeEmail.First())}." +
                    $"{CultureInfo.CurrentCulture.TextInfo.ToLower(NomeEmail.Last())}";
            }
            else
            {
                emailNormalizado = CultureInfo.CurrentCulture.TextInfo.ToLower(NomeEmail.First());
            }
            pessoaModel.Email = $"{emailNormalizado}@destinocerto.com";

            pessoaModel.Cadastro = DateTime.Now;

                
                
                _context.Add(pessoaModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
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
            return View(pessoaModel);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,PessoaModel pessoaModel)
        {
            if (id != pessoaModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pessoaModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PessoaModelExists(pessoaModel.Id))
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
            return View(pessoaModel);
        }

        // GET: Admin/Delete/5
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

        // POST: Admin/Delete/5
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

        public async Task<IActionResult> Gerenciar()
        {
            AdminModelAll modelAll = new AdminModelAll();
            modelAll.Usuarios = await _context.Pessoas.ToListAsync();
            modelAll.Destinos = await _context.Destinos.ToListAsync();
            List<string> vs = new List<string>();
            foreach (var item in modelAll.Destinos)
            {
                string Base64 = Convert.ToBase64String(item.ArrayImagem);
                string img = String.Format("data:image/jpeg;base64,{0}", Base64);
                item.ExtensaoArquivo = img;
            }
            modelAll.Atendimentos = await _context.Atendimentos.ToListAsync();
            modelAll.Reservas = await _context.Reservas.ToListAsync();
            return View (modelAll);
        }
    }
}
