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
    public class clm_memogesIIController : Controller
    {
        private clContext db = new clContext();

        // GET: clm_memogesII
        public ActionResult Index()
        {
            return View(db.Tmemoges.ToList());
        }

        // GET: clm_memogesII/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            clm_memogesII clm_memogesII = db.Tmemoges.Find(id);
            if (clm_memogesII == null)
            {
                return HttpNotFound();
            }
            return View(clm_memogesII);
        }

        // GET: clm_memogesII/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: clm_memogesII/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,item")] clm_memogesII clm_memogesII)
        {
            if (ModelState.IsValid)
            {
                db.Tmemoges.Add(clm_memogesII);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(clm_memogesII);
        }

        // GET: clm_memogesII/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            clm_memogesII clm_memogesII = db.Tmemoges.Find(id);
            if (clm_memogesII == null)
            {
                return HttpNotFound();
            }
            return View(clm_memogesII);
        }

        // POST: clm_memogesII/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,item")] clm_memogesII clm_memogesII)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clm_memogesII).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(clm_memogesII);
        }

        
        
        
        
        
        
        
        
        
        // GET: clm_memogesII/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null){return new HttpStatusCodeResult(HttpStatusCode.BadRequest);}

            //antes de remover, contar o número de linhas associadas a este item;
            //se não for zero, impedir a eliminação
            var T = from s in db.Tmemogeslinhas select s;
            int c; c = (T.Where(s => s.parteID==id)).Count();
            ViewBag.contadordelete = c;      //Response.Write(c);


            clm_memogesII clm_memogesII = db.Tmemoges.Find(id);
            if (clm_memogesII == null)
            {
                return HttpNotFound();
            }
            
            return View(clm_memogesII);
        }

        // POST: clm_memogesII/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            



            clm_memogesII clm_memogesII = db.Tmemoges.Find(id);
            db.Tmemoges.Remove(clm_memogesII);
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
