using PIM_WEB_MARTE.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace PIM_WEB.Controllers
{
    public class HomeController : Controller
    {



        private readonly Contexto db = new Contexto(); // Inicia o contexto do banco de dados

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Principal()
        {
            // Busca respostas
            var feedbacks = db.Feedback.ToList();

            // Verifica se os feedbacks foram recuperados
            if (feedbacks == null || !feedbacks.Any())
            {
                ViewBag.Message = "Nenhum feedback encontrado.";
            }
            else
            {
                // Calculo da média para cada pergunta
                var mediaResposta1 = feedbacks.Average(f => ConverterRespostaParaNumero(f.Resposta1));
                var mediaResposta2 = feedbacks.Average(f => ConverterRespostaParaNumero(f.Resposta2));
                var mediaResposta3 = feedbacks.Average(f => ConverterRespostaParaNumero(f.Resposta3));

                // Valores para a ViewBag
                ViewBag.MediaResposta1 = mediaResposta1;
                ViewBag.MediaResposta2 = mediaResposta2;
                ViewBag.MediaResposta3 = mediaResposta3;
            }

            return View();
        }


        // Converter respostas em valores numéricos
        private int ConverterRespostaParaNumero(string resposta)
        {
            if (resposta == "Muito Boa") return 100;
            if (resposta == "Boa") return 50;
            if (resposta == "Ruim") return 10;
            return 0;
        }



        public ActionResult Admin()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

        
            private readonly Contexto _context;

            public HomeController()
            {
                _context = new Contexto();
            }





        public ActionResult Obrigado()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Index(string email)
        {
            Console.WriteLine(email);
            // Gravar o email
            return Content($"Email recebido: {email}");
        }

        [HttpPost]

        public JsonResult SubmitFeedback(Feedback feedback)
        {
            if (ModelState.IsValid)
            {
                db.Feedback.Add(feedback);
                db.SaveChanges();

                // Se for com sucesso vai para tela de obrigado
                return Json(new { success = true, redirectUrl = Url.Action("Obrigado", "Home") });
            }

            // Em caso de falha retorna erros
            return Json(new { success = false, errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage) });
        }
    }
}
