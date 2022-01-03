using Destino_Certo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Destino_Certo.SendEmail;
using Destino_Certo.Data;
using Destino_Certo.Models.ADONET;

namespace Destino_Certo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISendEmail _sendEmail;
        private readonly IAuth _auth;

        public HomeController(ILogger<HomeController> logger, ISendEmail sendEmail, IAuth auth)
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
        public IActionResult Login()
        {
            var usuario = _auth.Login();
            if (usuario != null)
            {
                HttpContext.Session.SetInt32("Id", usuario.Id);
                HttpContext.Session.SetString("Login", usuario.Login);
                HttpContext.Session.SetString("Senha", usuario.Senha);
                HttpContext.Session.SetString("TipoConta", usuario.TipoConta);
                return RedirectToAction(nameof(Index));
            }
            return View("Index");
        }


        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View("Index");
        }

        
    }
}