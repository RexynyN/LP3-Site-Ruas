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
    public class TipoComercioController : Controller
    {
        private SeminarioLP3Container db = new SeminarioLP3Container();

        // GET: TipoComercio
        public ActionResult Index()
        {
            return View(db.TipoComercio.ToList());
        }

        // GET: TipoComercio/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoComercio tipoComercio = db.TipoComercio.Find(id);
            if (tipoComercio == null)
            {
                return HttpNotFound();
            }
            return View(tipoComercio);
        }

        // GET: TipoComercio/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoComercio/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdComercio,Descricao,OrgaoRegulador,Permissao,Nome")] TipoComercio tipoComercio)
        {
            if (ModelState.IsValid)
            {
                db.TipoComercio.Add(tipoComercio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoComercio);
        }

        // GET: TipoComercio/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoComercio tipoComercio = db.TipoComercio.Find(id);
            if (tipoComercio == null)
            {
                return HttpNotFound();
            }
            return View(tipoComercio);
        }

        // POST: TipoComercio/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdComercio,Descricao,OrgaoRegulador,Permissao,Nome")] TipoComercio tipoComercio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoComercio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoComercio);
        }

        // GET: TipoComercio/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoComercio tipoComercio = db.TipoComercio.Find(id);
            if (tipoComercio == null)
            {
                return HttpNotFound();
            }
            return View(tipoComercio);
        }

        // POST: TipoComercio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoComercio tipoComercio = db.TipoComercio.Find(id);
            db.TipoComercio.Remove(tipoComercio);
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
