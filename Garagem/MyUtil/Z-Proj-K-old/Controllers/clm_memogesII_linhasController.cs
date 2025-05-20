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
    public class clm_memogesII_linhasController : Controller
    {
        private clContext db = new clContext();

        // GET: clm_memogesII_linhas
        public ActionResult Index(string strfiltroitem, string itemID)
        {
            var T = from s in db.Tmemogeslinhas.OrderBy(Tmemogeslinhas => Tmemogeslinhas.dataY) select s;
            ViewBag.contadortotal = T.Count(); //total de registos 
            strfiltroitem = (strfiltroitem != null) ? strfiltroitem : "";
            strfiltroitem = strfiltroitem.ToUpper();
                      


            // filtrar a drop com os itens que contem a stringfiltro:
            var A = from s in db.Tmemoges select s; //declara auxiliar
            ViewBag.contadorauxtotal = A.Count();
            A = (A.Where(s => s.item.ToString().Contains(strfiltroitem))); //filtra auxiliar                
            int contadoraux = A.Count(); //conta nº de registos filtrados
            ViewBag.contadorauxfiltrado = contadoraux; //envia para a View

            //preencher a dropdownlist
            ViewBag.itemID = new SelectList(A, "Id", "item");




            //a linha seg. funciona se localizar usando código de item
            //T = (T.Where(s => s.parteID.ToString().Contains(strfiltroitem)));


            ViewBag.contadorlinhastotal = T.Count(); //total de linhas
            T = T.Where(s => s.parteID.ToString().Contains(itemID));
            ViewBag.contadorlinhasfiltradas = T.Count(); //total de linhas filtrado pela drop

            return View(T.ToList());

        }

        // GET: clm_memogesII_linhas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            clm_memogesII_linhas clm_memogesII_linhas = db.Tmemogeslinhas.Find(id);
            if (clm_memogesII_linhas == null)
            {
                return HttpNotFound();
            }
            return View(clm_memogesII_linhas);
        }

        // GET: clm_memogesII_linhas/Create
        public ActionResult Create()
        {
            ViewBag.parteID = new SelectList(db.Tmemoges, "ID", "item");
            return View();
        }

        // POST: clm_memogesII_linhas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,texto,dataY,parteID")] clm_memogesII_linhas clm_memogesII_linhas)
        {
            if (ModelState.IsValid)
            {
                db.Tmemogeslinhas.Add(clm_memogesII_linhas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.parteID = new SelectList(db.Tmemoges, "ID", "item", clm_memogesII_linhas.parteID);
            return View(clm_memogesII_linhas);
        }

        // GET: clm_memogesII_linhas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            clm_memogesII_linhas clm_memogesII_linhas = db.Tmemogeslinhas.Find(id);
            if (clm_memogesII_linhas == null)
            {
                return HttpNotFound();
            }
            ViewBag.parteID = new SelectList(db.Tmemoges, "ID", "item", clm_memogesII_linhas.parteID);
            return View(clm_memogesII_linhas);
        }

        // POST: clm_memogesII_linhas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,texto,dataY,parteID")] clm_memogesII_linhas clm_memogesII_linhas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clm_memogesII_linhas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.parteID = new SelectList(db.Tmemoges, "ID", "item", clm_memogesII_linhas.parteID);
            return View(clm_memogesII_linhas);
        }

        // GET: clm_memogesII_linhas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            clm_memogesII_linhas clm_memogesII_linhas = db.Tmemogeslinhas.Find(id);
            if (clm_memogesII_linhas == null)
            {
                return HttpNotFound();
            }
            return View(clm_memogesII_linhas);
        }

        // POST: clm_memogesII_linhas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            clm_memogesII_linhas clm_memogesII_linhas = db.Tmemogeslinhas.Find(id);
            db.Tmemogeslinhas.Remove(clm_memogesII_linhas);
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
