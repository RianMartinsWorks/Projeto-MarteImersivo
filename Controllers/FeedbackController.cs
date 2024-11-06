using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PIM_WEB_MARTE.Models;

namespace PIM_WEB_MARTE.Controllers
{
    public class FeedbackController : Controller
    {



        private Contexto db = new Contexto();

        // GET: Feedback
        public ActionResult Index()
        {
            var feedbacks = _context.Feedback.ToList();
            return View(db.Feedback.ToList());
        }

        public ActionResult Pesquisar(string searchTerm)
        {
            var feedbacks = from f in db.Feedback select f;

            if (!String.IsNullOrEmpty(searchTerm))
            {
                feedbacks = feedbacks.Where(f => f.Resposta1.Contains(searchTerm) ||
                                                 f.Resposta2.Contains(searchTerm) ||
                                                 f.Resposta3.Contains(searchTerm) ||
                                                 f.Sugestao.Contains(searchTerm));
            }

            return View(feedbacks.ToList());
        }


        // GET: Feedback/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feedback feedback = db.Feedback.Find(id);
            if (feedback == null)
            {
                return HttpNotFound();
            }
            return View(feedback);
        }

        // GET: Feedback/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Feedback/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Resposta1,Resposta2,Resposta3,Sugestao,Email")] Feedback feedback)
        {
            if (ModelState.IsValid)
            {
                db.Feedback.Add(feedback);
                db.SaveChanges();
                TempData["SuccessMessage"] = "Feedback enviado com sucesso!";
                return RedirectToAction("Index");
            }
            return View(feedback);
        }

        // GET: Feedback/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feedback feedback = db.Feedback.Find(id);
            if (feedback == null)
            {
                return HttpNotFound();
            }
            return View(feedback);
        }

        // POST: Feedback/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Resposta1,Resposta2,Resposta3,Sugestao,Email")] Feedback feedback)
        {
            if (ModelState.IsValid)
            {
                db.Entry(feedback).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(feedback);
        }

        // GET: Feedback/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feedback feedback = db.Feedback.Find(id);
            if (feedback == null)
            {
                return HttpNotFound();
            }
            return View(feedback);
        }

        // POST: Feedback/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Feedback feedback = db.Feedback.Find(id);
            db.Feedback.Remove(feedback);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private readonly Contexto _context; // o DbContext

        public FeedbackController()
        {
            _context = new Contexto(); // Inicia o contexto
        }


    }

}