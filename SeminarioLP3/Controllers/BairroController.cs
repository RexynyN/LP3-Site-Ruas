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
    public class BairroController : Controller
    {
        private SeminarioLP3Container db = new SeminarioLP3Container();

        // GET: Bairro
        public ActionResult Index()
        {
            return View(db.Bairro.ToList());
        }

        // GET: Bairro/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bairro bairro = db.Bairro.Find(id);
            if (bairro == null)
            {
                return HttpNotFound();
            }
            return View(bairro);
        }

        // GET: Bairro/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bairro/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdBairro,Cidade,UF,Zona,Nome")] Bairro bairro)
        {
            if (ModelState.IsValid)
            {
                db.Bairro.Add(bairro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bairro);
        }

        // GET: Bairro/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bairro bairro = db.Bairro.Find(id);
            if (bairro == null)
            {
                return HttpNotFound();
            }
            return View(bairro);
        }

        // POST: Bairro/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdBairro,Cidade,UF,Zona,Nome")] Bairro bairro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bairro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bairro);
        }

        // GET: Bairro/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bairro bairro = db.Bairro.Find(id);
            if (bairro == null)
            {
                return HttpNotFound();
            }
            return View(bairro);
        }

        // POST: Bairro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bairro bairro = db.Bairro.Find(id);
            db.Bairro.Remove(bairro);
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
