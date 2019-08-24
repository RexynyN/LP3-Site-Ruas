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
    public class RuaController : Controller
    {
        private SeminarioLP3Container db = new SeminarioLP3Container();

        // GET: Rua
        public ActionResult Index()
        {
            var rua = db.Rua.Include(r => r.Bairro).Include(r => r.TipoComercio);
            return View(rua.ToList());
        }

        // GET: Rua/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rua rua = db.Rua.Find(id);
            if (rua == null)
            {
                return HttpNotFound();
            }
            return View(rua);
        }

        // GET: Rua/Create
        public ActionResult Create()
        {
            ViewBag.FkBairro = new SelectList(db.Bairro, "IdBairro", "Cidade");
            ViewBag.FkTipoComercio = new SelectList(db.TipoComercio, "IdComercio", "Descricao");
            return View();
        }

        // POST: Rua/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdRua,FkBairro,FkTipoComercio,Nome,CEP")] Rua rua)
        {
            if (ModelState.IsValid)
            {
                db.Rua.Add(rua);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FkBairro = new SelectList(db.Bairro, "IdBairro", "Cidade", rua.FkBairro);
            ViewBag.FkTipoComercio = new SelectList(db.TipoComercio, "IdComercio", "Descricao", rua.FkTipoComercio);
            return View(rua);
        }

        // GET: Rua/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rua rua = db.Rua.Find(id);
            if (rua == null)
            {
                return HttpNotFound();
            }
            ViewBag.FkBairro = new SelectList(db.Bairro, "IdBairro", "Cidade", rua.FkBairro);
            ViewBag.FkTipoComercio = new SelectList(db.TipoComercio, "IdComercio", "Descricao", rua.FkTipoComercio);
            return View(rua);
        }

        // POST: Rua/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdRua,FkBairro,FkTipoComercio,Nome,CEP")] Rua rua)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rua).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FkBairro = new SelectList(db.Bairro, "IdBairro", "Cidade", rua.FkBairro);
            ViewBag.FkTipoComercio = new SelectList(db.TipoComercio, "IdComercio", "Descricao", rua.FkTipoComercio);
            return View(rua);
        }

        // GET: Rua/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rua rua = db.Rua.Find(id);
            if (rua == null)
            {
                return HttpNotFound();
            }
            return View(rua);
        }

        // POST: Rua/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Rua rua = db.Rua.Find(id);
            db.Rua.Remove(rua);
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
