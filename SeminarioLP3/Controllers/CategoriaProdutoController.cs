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
    public class CategoriaProdutoController : Controller
    {
        private SeminarioLP3Container db = new SeminarioLP3Container();

        // GET: CategoriaProduto
        public ActionResult Index()
        {
            var categoriaProdutoSet = db.CategoriaProdutoSet.Include(c => c.TipoComercio);
            return View(categoriaProdutoSet.ToList());
        }

        // GET: CategoriaProduto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriaProduto categoriaProduto = db.CategoriaProdutoSet.Find(id);
            if (categoriaProduto == null)
            {
                return HttpNotFound();
            }
            return View(categoriaProduto);
        }

        // GET: CategoriaProduto/Create
        public ActionResult Create()
        {
            ViewBag.FkTipoComercio = new SelectList(db.TipoComercio, "IdComercio", "Descricao");
            return View();
        }

        // POST: CategoriaProduto/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCategoriaProduto,FkTipoComercio,Tipo,Descricao")] CategoriaProduto categoriaProduto)
        {
            if (ModelState.IsValid)
            {
                db.CategoriaProdutoSet.Add(categoriaProduto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FkTipoComercio = new SelectList(db.TipoComercio, "IdComercio", "Descricao", categoriaProduto.FkTipoComercio);
            return View(categoriaProduto);
        }

        // GET: CategoriaProduto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriaProduto categoriaProduto = db.CategoriaProdutoSet.Find(id);
            if (categoriaProduto == null)
            {
                return HttpNotFound();
            }
            ViewBag.FkTipoComercio = new SelectList(db.TipoComercio, "IdComercio", "Descricao", categoriaProduto.FkTipoComercio);
            return View(categoriaProduto);
        }

        // POST: CategoriaProduto/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCategoriaProduto,FkTipoComercio,Tipo,Descricao")] CategoriaProduto categoriaProduto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categoriaProduto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FkTipoComercio = new SelectList(db.TipoComercio, "IdComercio", "Descricao", categoriaProduto.FkTipoComercio);
            return View(categoriaProduto);
        }

        // GET: CategoriaProduto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriaProduto categoriaProduto = db.CategoriaProdutoSet.Find(id);
            if (categoriaProduto == null)
            {
                return HttpNotFound();
            }
            return View(categoriaProduto);
        }

        // POST: CategoriaProduto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CategoriaProduto categoriaProduto = db.CategoriaProdutoSet.Find(id);
            db.CategoriaProdutoSet.Remove(categoriaProduto);
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
