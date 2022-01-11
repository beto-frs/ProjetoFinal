using Destino_Certo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Destino_Certo.SendEmail;
using Destino_Certo.Data;
using Destino_Certo.Models.ADONET;
using Destino_Certo.Crypto;

namespace Destino_Certo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        ISendEmail _sendEmail;
        IAuth _auth;

        public HomeController(ILogger<HomeController> logger, ISendEmail sendEmail, IAuth auth, ICrypto crypto)
        {
            _logger = logger;
            _sendEmail = sendEmail;
            _auth = auth;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Envio()
        {
            string _email = "francisco.roberto@ufn.edu.br";
            _sendEmail.Marketing(_email);
            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string login, string senha)
        {

            var usuario = _auth.Login(login,senha);
            if (usuario != null)
            {
                string[] PrimeiroNome = usuario.Nome.Split(" ");
                string PNome = PrimeiroNome[0];
                HttpContext.Session.SetString("Nome", PNome);
                HttpContext.Session.SetInt32("Id", usuario.Id);
                HttpContext.Session.SetString("NomeCompleto", usuario.Nome);
                HttpContext.Session.SetString("Login", usuario.Login);
                HttpContext.Session.SetString("Senha", usuario.Senha);
                HttpContext.Session.SetString("Email", usuario.Email);
                HttpContext.Session.SetString("Telefone", usuario.Telefone);
                HttpContext.Session.SetString("TipoConta", usuario.TipoConta);
                return RedirectToAction(nameof(Index));
            }
            return View("Index");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            Autenticacao us = new Autenticacao();
            return RedirectToAction("Index");
        }

        public ActionResult About()
        {
            return View();
        }
        
    }
}