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
    public class clm_clientesController : Controller
    {
        private clContext db = new clContext();

        // GET: clm_clientes
        public ActionResult Index(string stringfiltro)
        {
            if (stringfiltro!=null)
                return View(db.Tclientes.Where(m => m.cliente.Contains(stringfiltro)).ToList());
            else
                return View(db.Tclientes.ToList());
        }

        // GET: clm_clientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            clm_clientes clm_clientes = db.Tclientes.Find(id);
            if (clm_clientes == null)
            {
                return HttpNotFound();
            }
            return View(clm_clientes);
        }

        // GET: clm_clientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: clm_clientes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,codcli,cliente,telefone,telemovel,email,fax,morada,CP,NIF,codcerper,PortalAT_login,PortalAT_senha,PortalSS_login,PortalSS_senha,PortalIAPMEI_login,PortalIAPMEI_senha,PortalVCTT_login,PortalVCTT_senha,PortalIEFP_login,PortalIEFP_senha,PortalINE_login,PortalINE_senha,Fundo_comp_login,Fundo_comp_senha,Banco_de_Portugal_login,Banco_de_Portugal_senha,Siifse_login,Siifse,SAGE_CNT_utilizador,SAGE_CNT_senha,SAGE_FAC_utilizador,SAGE_FAC_senha,acesso_remoto_login,acesso_remoto_senha,acesso_remoto_descricao,rel_unico_utilizador,rel_unico_senha,portugal_2020_utilizador,portugal_2020_senha,diversos1,diversos2,Diversos3,NumContrato,dataY")] clm_clientes clm_clientes)
        {
            if (ModelState.IsValid)
            {
                db.Tclientes.Add(clm_clientes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(clm_clientes);
        }

        // GET: clm_clientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            clm_clientes clm_clientes = db.Tclientes.Find(id);
            if (clm_clientes == null)
            {
                return HttpNotFound();
            }
            return View(clm_clientes);
        }

        // POST: clm_clientes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,codcli,cliente,telefone,telemovel,email,fax,morada,CP,NIF,codcerper,PortalAT_login,PortalAT_senha,PortalSS_login,PortalSS_senha,PortalIAPMEI_login,PortalIAPMEI_senha,PortalVCTT_login,PortalVCTT_senha,PortalIEFP_login,PortalIEFP_senha,PortalINE_login,PortalINE_senha,Fundo_comp_login,Fundo_comp_senha,Banco_de_Portugal_login,Banco_de_Portugal_senha,Siifse_login,Siifse,SAGE_CNT_utilizador,SAGE_CNT_senha,SAGE_FAC_utilizador,SAGE_FAC_senha,acesso_remoto_login,acesso_remoto_senha,acesso_remoto_descricao,rel_unico_utilizador,rel_unico_senha,portugal_2020_utilizador,portugal_2020_senha,diversos1,diversos2,Diversos3,NumContrato,dataY")] clm_clientes clm_clientes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clm_clientes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(clm_clientes);
        }

        // GET: clm_clientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            clm_clientes clm_clientes = db.Tclientes.Find(id);
            if (clm_clientes == null)
            {
                return HttpNotFound();
            }
            return View(clm_clientes);
        }

        // POST: clm_clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            clm_clientes clm_clientes = db.Tclientes.Find(id);
            db.Tclientes.Remove(clm_clientes);
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
