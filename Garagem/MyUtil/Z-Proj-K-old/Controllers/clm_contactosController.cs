using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KRONOS.DAL;
using KRONOS.Models;

namespace KRONOS.Controllers
{
    public class clm_contactosController : Controller
    {
        private clContext db = new clContext();

        // GET: clm_contactos
        public ActionResult Index(string stringfiltro)
        {
            if (stringfiltro != null)
                return View(db.Tcontactos.Where(m => m.cliente.Contains(stringfiltro)).ToList());
            else
                return View(db.Tcontactos.ToList());
        }

        // GET: clm_contactos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            clm_contactos clm_contactos = db.Tcontactos.Find(id);
            if (clm_contactos == null)
            {
                return HttpNotFound();
            }
            return View(clm_contactos);
        }

        // GET: clm_contactos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: clm_contactos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,cliente,telefone,telemovel,morada,anotacoes1,anotacoes2")] clm_contactos clm_contactos)
        {
            if (ModelState.IsValid)
            {
                db.Tcontactos.Add(clm_contactos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(clm_contactos);
        }

        // GET: clm_contactos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            clm_contactos clm_contactos = db.Tcontactos.Find(id);
            if (clm_contactos == null)
            {
                return HttpNotFound();
            }
            return View(clm_contactos);
        }

        // POST: clm_contactos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,cliente,telefone,telemovel,morada,anotacoes1,anotacoes2")] clm_contactos clm_contactos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clm_contactos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(clm_contactos);
        }

        // GET: clm_contactos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            clm_contactos clm_contactos = db.Tcontactos.Find(id);
            if (clm_contactos == null)
            {
                return HttpNotFound();
            }
            return View(clm_contactos);
        }

        // POST: clm_contactos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            clm_contactos clm_contactos = db.Tcontactos.Find(id);
            db.Tcontactos.Remove(clm_contactos);
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
