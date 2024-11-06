using PIM_WEB_MARTE.Models;
using System.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace PIM_WEB_MARTE.Controllers

{
    public class AdminController : Controller
    {
        private readonly Contexto _context = new Contexto();


        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
       
        public ActionResult Entrar(AdminModel model)
        {
            // Verifica se as credenciais correspondem a um usuário no banco de dados
            var admin = _context.Admin
                .FirstOrDefault(a => a.Login == model.Login && a.Senha == model.Senha);

            if (admin != null)
            {
                // Login bem-sucedido
                return RedirectToAction("Index", "Feedback");
            }

            // Falha no login
            ModelState.AddModelError("", "Usuário ou senha inválidos.");
            return View("Index", model);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }
    }


}


    