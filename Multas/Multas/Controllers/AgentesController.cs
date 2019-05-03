using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Multas.Models;

namespace Multas.Controllers
{
    public class AgentesController : Controller
    {
        // cria a VAR que representa a BD
        private MultasDB db = new MultasDB();

        // GET: Agentes
        public ActionResult Index()
        {
            // procura a totalidade de Agentes na BD
            // instrução em LINQ
            // SELECT * FROM Agentes ORDER BY nome
            var listaAgentes = db.Agentes.OrderBy(a => a.Nome).ToList();

            return View(listaAgentes);
            //return View(db.Agentes.ToList());
        }

        // GET: Agentes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // SELECT * FROM Agentes WHERE Id=id
            Agentes agentes = db.Agentes.Find(id);
            if (agentes == null)
            {
                // o Agente não foi encontrdo
                // return RedirectToAction("Index");
                return HttpNotFound();
            }
            return View(agentes);
        }

        // GET: Agentes/Create
        public ActionResult Create()
        {
            return View();
        }

        // **************************** CREATE ******************************************

        // POST: Agentes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nome,Esquadra,Fotografia")] Agentes agentes)
        {
            if (ModelState.IsValid)
            {
                db.Agentes.Add(agentes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            // mostra na View os dados do Agente
            return View(agentes);
        }

        // *************************** EDITAR ***************************************

        // GET: Agentes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                // ocorre o erro porque o utilizador pode andar a fazer asneiras
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                //return RedirectToAction("Index");
            }
            // SELECT * FROM Agentes WHERE Id=id
            Agentes agentes = db.Agentes.Find(id);

            // o Agente foi encontrado?
            if (agentes == null)
            {
                // o Agente não foi encontrado
                return HttpNotFound();
                //return RedirectToAction("Index");
            }

            // mostra na View os dados do Agente
            return View(agentes);
        }


        // POST: Agentes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nome,Esquadra,Fotografia")] Agentes agentes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(agentes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            // mostra na View os dados do Agente
            return View(agentes);
        }

        // +++++++++++++++++++++++++++ DELETE ***************************************+
        // GET: Agentes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                // return RedirectToAction("Index");
            }

            // SELECT * FROM Agentes WHERE Id=id
            Agentes agentes = db.Agentes.Find(id);

            // o Agente foi encontrado?
            if (agentes == null)
            {
                return HttpNotFound();
                // return RedirectToAction("Index");
            }

            // mostra na View os dados do Agente
            return View(agentes);
        }




        // POST: Agentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Agentes agentes = db.Agentes.Find(id);
            db.Agentes.Remove(agentes);
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
    }
}
