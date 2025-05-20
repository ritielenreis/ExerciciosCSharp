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
    public class clm_memogesIController : Controller
    {
        private clContext db = new clContext();

        // GET: clm_memogesI
        public ActionResult Index(string strfiltroitem, string strfiltrotexto)
        {
            var T = from s in db.TMemoGesI.OrderBy(TMemoGes => TMemoGes.item) select s;
            ViewBag.contadortotal = T.Count();
            strfiltroitem = (strfiltroitem != null) ? strfiltroitem : "";
            strfiltrotexto = (strfiltrotexto != null) ? strfiltrotexto : "";

            strfiltroitem = strfiltroitem.ToUpper();
            strfiltrotexto = strfiltrotexto.ToUpper();

            if (strfiltroitem == "")//procura apenas em texto 1 ou texto 2
            {
                T = (
                T.Where(s =>
                s.texto1.ToUpper().Contains(strfiltrotexto)
                ||
                s.texto2.ToUpper().Contains(strfiltrotexto)
                )
                );
            }
            else
            {
                if (strfiltrotexto != "")
                {
                    T = (
                    T.Where(s =>
                    s.item.ToUpper().Contains(strfiltroitem)
                    && (s.texto1.ToUpper().Contains(strfiltrotexto) || s.texto2.ToUpper().Contains(strfiltrotexto))
                    )
                    );
                }
                else
                {
                    T = (T.Where(s => s.item.ToUpper().Contains(strfiltroitem)));
                }
            }
            ViewBag.contadorparcial = T.Count();
            return View(T.ToList());
        }

        // GET: clm_memogesI/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            clm_memogesI clm_memogesI = db.TMemoGesI.Find(id);
            if (clm_memogesI == null)
            {
                return HttpNotFound();
            }
            return View(clm_memogesI);
        }

        // GET: clm_memogesI/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: clm_memogesI/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,item,texto1,texto2")] clm_memogesI clm_memogesI)
        {
            if (ModelState.IsValid)
            {
                db.TMemoGesI.Add(clm_memogesI);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(clm_memogesI);
        }

        // GET: clm_memogesI/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            clm_memogesI clm_memogesI = db.TMemoGesI.Find(id);
            if (clm_memogesI == null)
            {
                return HttpNotFound();
            }
            return View(clm_memogesI);
        }

        // POST: clm_memogesI/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,item,texto1,texto2")] clm_memogesI clm_memogesI)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clm_memogesI).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(clm_memogesI);
        }

        // GET: clm_memogesI/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            clm_memogesI clm_memogesI = db.TMemoGesI.Find(id);
            if (clm_memogesI == null)
            {
                return HttpNotFound();
            }
            return View(clm_memogesI);
        }

        // POST: clm_memogesI/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            clm_memogesI clm_memogesI = db.TMemoGesI.Find(id);
            db.TMemoGesI.Remove(clm_memogesI);
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
