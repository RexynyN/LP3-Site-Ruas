using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SeminarioLP3.Models;

namespace SeminarioLP3.Controllers
{
    public class LojaController : Controller
    {
        private SeminarioLP3Container db = new SeminarioLP3Container();

        // GET: Loja
        public ActionResult Index()
        {
            var loja = db.Loja.Include(l => l.Rua);
            return View(loja.ToList());
        }

        // GET: Loja/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loja loja = db.Loja.Find(id);
            if (loja == null)
            {
                return HttpNotFound();
            }
            return View(loja);
        }

        // GET: Loja/Create
        public ActionResult Create()
        {
            ViewBag.FkRua = new SelectList(db.Rua, "IdRua", "Nome");
            return View();
        }

        // POST: Loja/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdLoja,FkRua,CNPJ,NomeComercial,RazaoSocial,Telefone,Site")] Loja loja)
        {
            if (ModelState.IsValid)
            {
                db.Loja.Add(loja);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FkRua = new SelectList(db.Rua, "IdRua", "Nome", loja.FkRua);
            return View(loja);
        }

        // GET: Loja/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loja loja = db.Loja.Find(id);
            if (loja == null)
            {
                return HttpNotFound();
            }
            ViewBag.FkRua = new SelectList(db.Rua, "IdRua", "Nome", loja.FkRua);
            return View(loja);
        }

        // POST: Loja/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdLoja,FkRua,CNPJ,NomeComercial,RazaoSocial,Telefone,Site")] Loja loja)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loja).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FkRua = new SelectList(db.Rua, "IdRua", "Nome", loja.FkRua);
            return View(loja);
        }

        // GET: Loja/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loja loja = db.Loja.Find(id);
            if (loja == null)
            {
                return HttpNotFound();
            }
            return View(loja);
        }

        // POST: Loja/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Loja loja = db.Loja.Find(id);
            db.Loja.Remove(loja);
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
